using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nashoca.Application.Commands;
using Nashoca.Application.DTOs;
using Nashoca.Application.Queries;

namespace Nashoca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerbsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VerbsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<VerbDto>>> GetAll()
        {
            var verbs = await _mediator.Send(new GetAllVerbsQuery());
            return Ok(verbs);
        }

        [HttpPost]
        public async Task<IActionResult> AddVerb([FromBody] VerbDto verbDto)
        {
            await _mediator.Send(new CreateVerbCommand { Verb = verbDto });
            return Ok();
        }
    }
}
