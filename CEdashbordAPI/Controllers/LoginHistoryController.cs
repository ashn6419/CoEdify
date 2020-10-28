using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace CEdashbordAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginHistoryController : ControllerBase
    {
        IUnitOfWork uow;
        public LoginHistoryController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpGet]
        public IActionResult GetAllLoginHistories()
        {
            IEnumerable<LoginHistory> loginHistories = uow.LoginHistoryRepo.GetAll();
            if (loginHistories.Count() > 0)
                return Ok(loginHistories);
            else
                return StatusCode(StatusCodes.Status204NoContent, "Records not found!");

        }

        [HttpGet]
        [Route("GetLoginHistoryById/{id}")]
        public IActionResult GetLoginHistoryById(int id = 0)
        {
            LoginHistory loginHistory = uow.LoginHistoryRepo.GetLoginHisoryById((int)id);
            if (loginHistory.LoginHistoryId > 0)
                return Ok(loginHistory);
            else
                return StatusCode(StatusCodes.Status204NoContent, "Login history not found!");
        }

        [HttpPost()]
        public IActionResult AddLoginHistory([FromBody] LoginHistory loginHistory)
        {
            if (loginHistory == null)
                return StatusCode(StatusCodes.Status400BadRequest, "parameter is null");

            try
            {
                loginHistory.CreatedDate = DateTime.Now;
                int result = uow.LoginHistoryRepo.AddLoginHistory(loginHistory);
                if (result > 0)
                    return Created("LoginHistory/AddLoginHistory", loginHistory);
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, loginHistory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
