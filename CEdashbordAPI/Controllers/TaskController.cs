using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEdashbordAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        IUnitOfWork uow;
        public TaskController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            IEnumerable<Tasks> tasks = uow.TaskRepo.GetAll();
            if (tasks.Count() > 0)
                return Ok(tasks);
            else
                return StatusCode(StatusCodes.Status204NoContent, "Records not found!");

        }

        [HttpGet]
        [Route("GetTaskById/{id}")]
        public IActionResult GetTaskById(int id = 0)
        {
            Tasks task = uow.TaskRepo.GetById((int)id);
            if (task.TaskId > 0)
                return Ok(task);
            else
                return StatusCode(StatusCodes.Status204NoContent, "task not found!");
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] Tasks task)
        {
            if (task == null)
                return StatusCode(StatusCodes.Status400BadRequest, "task parameter is null");

            try
            {
                task.CreatedDate = DateTime.Now;
                int result = uow.TaskRepo.Add(task);
                if (result > 0)
                    return Created("Taks/AddTask", task);
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] Tasks task)
        {
            if (task == null)
                return StatusCode(StatusCodes.Status400BadRequest, "task parameter is null");

            try
            {
                task.ModifiedDate = DateTime.Now;
                int result = uow.TaskRepo.Update(task);
                if (result > 0)
                    return Ok(task);
                else
                    return StatusCode(StatusCodes.Status304NotModified, task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{TaskId}")]
        public IActionResult DeleteTask(int TaskId)
        {
            if (TaskId <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, "parameter is not passed!");

            try
            {
                int result = uow.TaskRepo.Delete(TaskId);
                if (result > 0)
                    return Ok("Record deleted!");
                else
                    return StatusCode(StatusCodes.Status200OK, "task record not deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
