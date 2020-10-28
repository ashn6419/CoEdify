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
    public class RoleController : ControllerBase
    {
        IUnitOfWork uow;
        public RoleController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            IEnumerable<Role> roles = uow.roleRepo.GetAll();
            if (roles.Count() > 0)
                return Ok(roles);
            else
                return StatusCode(StatusCodes.Status204NoContent, "Records not found!");

        }

        [HttpGet]
        [Route("GetRoleById/{id}")]
        public IActionResult GetRoleById(int id = 0)
        {
            Role role = uow.roleRepo.GetRoleById((int)id);
            if (role.RoleId > 0)
                return Ok(role);
            else
                return StatusCode(StatusCodes.Status204NoContent, "user not found!");
        }

        //[HttpGet()]
        //[Route("GetUserLogin/{Useremail}")]
        //public IActionResult GetUserLogin(string Useremail)
        //{
        //    UserLogin userLogin = uow.loginRepo.GetUserLogin(Useremail);
        //    if (userLogin.UserLoginId > 0)
        //        return Ok(userLogin);
        //    else
        //        return StatusCode(StatusCodes.Status204NoContent, "user not found!");
        //}

        [HttpPost()]
        public IActionResult AddRole( [FromBody] Role role) 
        {
            if (role == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Role parameter is null");

            try
            {
                role.CreatedDate = DateTime.Now;
                int result = uow.roleRepo.AddRole(role);
                if (result > 0)
                    return Created("Role/AddRole",role); 
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, role);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, [FromBody] Role role)  
        {
            if (role == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Role parameter is null");

            try
            {
                role.ModifiedDate = DateTime.Now;
                int result = uow.roleRepo.UpdateRole(role);
                if (result > 0)
                    return Ok(role);
                else
                    return StatusCode(StatusCodes.Status304NotModified, role);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{RoleId}")]
        public IActionResult DeleteRole(int RoleId)  
        {
            if (RoleId <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, "parameter is not passed!");

            try
            {

                int result = uow.roleRepo.DeleteRole(RoleId);
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
