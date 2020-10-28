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
    public class TaskItemController : ControllerBase
    {
        IUnitOfWork uow;
        public TaskItemController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public IActionResult GetAllTaskItems()
        {
            IEnumerable<TaskItem> taskItems = uow.TaskItemRepo.GetAll();
            if (taskItems.Count() > 0)
                return Ok(taskItems);
            else
                return StatusCode(StatusCodes.Status204NoContent, "Records not found!");
        }

        [HttpGet]
        [Route("GetTaskItemById/{id}")]
        public IActionResult GetTaskItemById(int id = 0)
        {
            TaskItem taskItem = uow.TaskItemRepo.GetById((int)id);
            if (taskItem.TaskId > 0)
                return Ok(taskItem);
            else
                return StatusCode(StatusCodes.Status204NoContent, "task item not found!");
        }
        [HttpGet]
        [Route("GetTaskItemByTaskId/{id}")]
        public IActionResult GetTaskItemByTaskId(int id = 0)
        {
            TaskItem taskItem = uow.TaskItemRepo.GetById((int)id);
            if (taskItem.TaskId > 0)
                return Ok(taskItem);
            else
                return StatusCode(StatusCodes.Status204NoContent, "task item not found!");
        }

        [HttpPost]
        public IActionResult AddTaskItem([FromBody] TaskItem taskItem)
        {
            if (taskItem == null)
                return StatusCode(StatusCodes.Status400BadRequest, "task parameter is null");

            try
            {
                taskItem.CreatedDate = DateTime.Now;
                int result = uow.TaskItemRepo.Add(taskItem);
                if (result > 0)
                    return Created("TaksItem/AddTaskItem", taskItem);
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, taskItem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateTaskItem(int id, [FromBody] TaskItem taskItem)
        {
            if (taskItem == null)
                return StatusCode(StatusCodes.Status400BadRequest, "task item parameter is null");

            try
            {
                taskItem.ModifiedDate = DateTime.Now;
                int result = uow.TaskItemRepo.Update(taskItem);
                if (result > 0)
                    return Ok(taskItem);
                else
                    return StatusCode(StatusCodes.Status304NotModified, taskItem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{TaskItemId}")]
        public IActionResult DeleteTask(int TaskItemId)
        {
            if (TaskItemId <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, "parameter is not passed!");

            try
            {
                int result = uow.TaskItemRepo.Delete(TaskItemId);
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
