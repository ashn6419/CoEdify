using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Abstraction;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEdashbordAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUnitOfWork uow;
        public LoginController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IActionResult GetAllUserLogins()
        {
            IEnumerable<UserLogin> userLogins = uow.loginRepo.GetAll();
            return Ok(userLogins);
        }

        [HttpGet]
        [Route("GetUserLoginById/{id}")]
        public IActionResult GetUserLoginById(int id = 0)
        {
            UserLogin userLogin = uow.loginRepo.GetUserLoginById((int)id);
            if (userLogin.UserLoginId > 0)
                return Ok(userLogin);
            else
                return StatusCode(StatusCodes.Status204NoContent, "user not found!");
        }

        [HttpGet]
        [Route("GetUserLogin/{Useremail}")]
        public IActionResult GetUserLogin(string Useremail)
        {
            UserLogin userLogin = uow.loginRepo.GetUserLogin(Useremail);
            if (userLogin.UserLoginId > 0)
                return Ok(userLogin);
            else
                return StatusCode(StatusCodes.Status204NoContent, "user not found!");
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUserPassword(int id, [FromBody] UserLogin user)
        {
            if (user == null)
                return StatusCode(StatusCodes.Status400BadRequest, "user parameter is null");

            try
            {
                user.ModifiedDate = DateTime.Now;
                int result = uow.loginRepo.UpdateUserPassword(user);
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
                return StatusCode(StatusCodes.Status400BadRequest, "user parameter is null");

            try
            {

                int result = uow.loginRepo.DeleteUser(UserId);
                if (result > 0)
                    return Ok("User record deleted");
                else
                    return StatusCode(StatusCodes.Status204NoContent, "User record not found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("DoLogin")]
        public IActionResult DoLogin([FromBody] UserLogin user)
        {
            UserLogin userLogin = uow.loginRepo.DoLogin(user);

            if (userLogin.UserLoginId > 0)
            {
                return Ok(userLogin);
            }
            else
            {
                return NotFound("Failure! No Authenticated");
            }
        }
        //[HttpGet]
        //[Route("GetUserLogins")]
        //public JsonResult GetUserLogins()
        //{

        //    List<UserLogin> userLogins = new List<UserLogin>();
        //    using (SqlConnection con = new SqlConnection(dbCon.ConStr))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "usp_GetAllUserLogins";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    UserLogin userLogin = new UserLogin();
        //                    userLogin.UserLoginId = Convert.ToInt32(reader["UserloginId"]);
        //                    userLogin.UserEmail = reader["UserEmail"].ToString();
        //                    userLogin.Password = reader["Password"].ToString();

        //                    userLogins.Add(userLogin);
        //                }
        //            }
        //        }
        //        con.Close();

        //        var users = new JsonResult(userLogins);
        //        if (userLogins.Count > 0)
        //        {
        //            users.StatusCode = Convert.ToInt32(HttpStatusCode.OK); ;
        //        }
        //        else
        //        {
        //            users.StatusCode = Convert.ToInt32(HttpStatusCode.NoContent);
        //        }
        //        return users;
        //    }
        //}
    }
}
