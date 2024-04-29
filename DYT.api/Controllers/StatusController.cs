using DYT.businessLogic.Status.Models;
using DYT.businessLogic.Status.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DYT.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StatusController : Controller
    {
        private readonly ISender _sender;

        public StatusController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusDTO>>> GetAllStatus() 
        {
            return Ok(await _sender.Send(new GetAllStatusQuery()));
        }
    }
}
