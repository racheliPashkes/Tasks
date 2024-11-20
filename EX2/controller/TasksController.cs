using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EX2.models;
using EX2.services;

namespace EX2.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public IEnumerable<TaskModel> GetTasks()
        {
            return _taskService.GetTasks();
        }
        [HttpPost]
        public IActionResult AddTask(string Id, string Name, string Status, string DueDate)
        {
            _taskService.addTask( Id, Name,Status, DueDate); 
            return CreatedAtAction(nameof(GetTasks), new { id = Id , name = Name , status = Status,dueDate=DueDate  });
        }
        [HttpDelete]
        public IActionResult deleteTask([FromQuery] string id)
        {
            _taskService.DeleteTaskById(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult updateTask([FromBody] TaskModel newTask)
        {
            _taskService.updateTask(newTask);
            return Ok();
        }
    }
}
