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
    public class QualificationController : ControllerBase
    {
        IUnitOfWork uow;
        public QualificationController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IActionResult GetAllQualifications()
        {
            IEnumerable<Qualification> qualifications = uow.qualificationRepo.GetAll();
            if (qualifications.Count() > 0)
                return Ok(qualifications);
            else
                return StatusCode(StatusCodes.Status204NoContent, "Records not found!");

        }

        [HttpGet]
        [Route("GetQualificationById/{id}")]
        public IActionResult GetQualificationById(int id = 0)
        {
            Qualification qualification = uow.qualificationRepo.GetQualificationById((int)id);
            if (qualification.QualificationId > 0)
                return Ok(qualification);
            else
                return StatusCode(StatusCodes.Status204NoContent, "Qualification not found!");
        }

        [HttpPost]
        public IActionResult AddQualification([FromBody] Qualification qualification)
        {
            if (qualification == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Role parameter is null");

            try
            {
                qualification.CreatedDate = DateTime.Now;
                int result = uow.qualificationRepo.AddQualification(qualification);
                if (result > 0)
                    return Created("Qualification/AddQualification", qualification);
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, qualification);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQualification(int id, [FromBody] Qualification qualification)
        {
            if (qualification == null)
                return StatusCode(StatusCodes.Status400BadRequest, "qualification parameter is null");

            try
            {
                qualification.ModifiedDate = DateTime.Now;
                int result = uow.qualificationRepo.UpdateQualification(qualification);
                if (result > 0)
                    return Ok(qualification);
                else
                    return StatusCode(StatusCodes.Status304NotModified, qualification);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{qualificationId}")]
        public IActionResult DeleteQualification(int qualificationId)
        {
            if (qualificationId <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, "parameter is not passed!");

            try
            {

                int result = uow.qualificationRepo.DeleteQualification(qualificationId);
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
