using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CEdashbordAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUnitOfWork uow;
        public UserController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public IActionResult GetAllUsers()
        {
            IEnumerable<User> users = uow.userRepo.GetAll();
            if (users.Count() > 0)
                return Ok(users);
            else
                return StatusCode(StatusCodes.Status204NoContent, "Records not found!");

        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public IActionResult GetUserById(int id = 0)
        {
            User user = uow.userRepo.GetUserById((int)id);
            if (user.UserId > 0)
                return Ok(user);
            else
                return StatusCode(StatusCodes.Status204NoContent, "user not found!");
        }
        // POST api/<LoginController>
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
                return StatusCode(StatusCodes.Status400BadRequest, "User parameter is null");

            try
            {
                user.CreatedDate = DateTime.Now;
                User objUser = uow.userRepo.AddUser(user);
                if (objUser.UserLoginId > 0)
                {
                    return Created("User/AddUser", objUser);
                }
                else if (objUser.UserLoginId == -99)
                {
                    return StatusCode(StatusCodes.Status302Found, user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (user == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Role parameter is null");

            try
            {
                user.ModificationDate = DateTime.Now;
                int result = uow.userRepo.UpdateUser(user);
                if (result > 0)
                    return Ok(user);
                else
                    return StatusCode(StatusCodes.Status304NotModified, user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{UserId}")]
        public IActionResult DeleteUser(int UserId)
        {
            if (UserId <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, "parameter is not passed!");

            try
            {

                int result = uow.userRepo.DeleteUser(UserId);
                if (result > 0)
                    return Ok("Record deleted!");
                else
                    return StatusCode(StatusCodes.Status200OK, "User record not deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
