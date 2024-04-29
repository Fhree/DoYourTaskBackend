using DYT.businessLogic.TypeTask.Models;
using DYT.businessLogic.TypeTask.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DYT.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TypeTaskController : Controller
    {
        private readonly ISender _sender;

        public TypeTaskController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeTaskDTO>>> GetAllTypeTasks()
        {
            return Ok(await _sender.Send(new GetAllTypeTaskQuery()));
        }
    }
}
