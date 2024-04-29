using DYT.businessLogic.Tasks.Commands;
using DYT.businessLogic.Tasks.Models;
using DYT.businessLogic.Tasks.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DYT.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TasksController : Controller
    {
        private readonly IGetAllTasksQueryHandler _getAllTasksQueryHandler;
        private readonly IGetTaskQueryHandler _getTaskQueryHandler;
        private readonly ISender _sender;

        public TasksController(IGetAllTasksQueryHandler getAllTasksQueryHandler,
            IGetTaskQueryHandler getTaskQueryHandler,
            ISender sender)
        {
            _getAllTasksQueryHandler = getAllTasksQueryHandler;
            _getTaskQueryHandler = getTaskQueryHandler;
            _sender = sender;
        }

        [HttpGet]
        [ActionName("GetAllTasks")]
        public async Task<ActionResult<List<TaskDTO>>> GetAllTasks()
        {
            var result = _getAllTasksQueryHandler.GetAllTasks();

            if (result == null || result.Count == 0)
                return NoContent();
            else
                return Ok(result);
        }

        [HttpGet]
        [ActionName("GetTask")]
        public async Task<ActionResult<TaskDTO>> GetTask([FromQuery] int id)
        {
            var result = _getTaskQueryHandler.GetTask(id);

            if (result == null) return NoContent();

            return Ok(result);
        }

        [HttpPost(Name = "CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody]CreateTaskCommand task)
        {
            await _sender.Send(task);
            return Ok();
        }

        [HttpPut]
        [ActionName("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody]UpdateTaskCommand task)
        {
            await _sender.Send(task);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask([FromQuery]int id) 
        {
            await _sender.Send(new DeleteTaskCommand { Id = id });
            return Ok();
        }
    }
}
