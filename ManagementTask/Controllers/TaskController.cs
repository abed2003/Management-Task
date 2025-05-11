using ManagementTask.DTO.TaskDTO;
using ManagementTask.DTO.UsersDTO;
using ManagementTask.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTask.Controllers
{
    [Route("Task/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _context;
        public TaskController(TaskService context)
        {
            _context = context;
        }
        [HttpPost("AddTask")]
        public IActionResult AddTask([FromBody]AddTaskDto AddTask)
        {
            return Ok(_context.AddTask(AddTask));
        }
        [HttpDelete("DeleteTaks/{TaskId}")]
        public IActionResult DeleteTaks(int TaskId)
        {
            return Ok(_context.DeleteTaks(TaskId));
        }
        [HttpPut("UpdateTaks/{TaskId}")]
        public IActionResult UpdateTaks([FromBody]UpdateTaskDto NewTaskData, int TaskId)
        {
            return Ok(_context.UpdateTaks(NewTaskData, TaskId));
        }
        [HttpGet("GetAllTasks")]
        public IActionResult GetAllTasks()
        {
            var result = _context.GetAllTasks();
            if (result == null || !result.Any())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetTaskByUserId/{UserId}")]
        public IActionResult GetTaskByUserId(string UserId)
        {
            var result = _context.GetTaskByUserId(UserId);
            if (result == null || !result.Any())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetTaskById/{TaskId}")]
        public IActionResult GetTaskById(int TaskId)
        {
            var result = _context.GetTaskById(TaskId);
            if (result == null || !result.Any())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
