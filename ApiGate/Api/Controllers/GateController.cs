using ApiGate.Application.Gates.Commands;
using ApiGate.Application.Gates.Commands.DeleteAllGates;
using ApiGate.Application.Gates.Commands.DeleteGate;
using ApiGate.Application.Gates.Commands.PostGate;
using ApiGate.Application.Gates.Commands.PostGateList;
using ApiGate.Application.Gates.Queries.GetGateDetails;
using ApiGate.Application.Gates.Queries.GetGates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {

        private readonly IMediator _mediator;
        public GateController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<List<GateBriefDto>>> GetGates()
        {
            return await _mediator.Send(new GetGatesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GateDetailsDto>> GetGate(int id)
        {
            return await _mediator.Send(new GetGateDetailsQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostGate([FromBody] PostGateDto pgd)
        {
            return await _mediator.Send(new PostGateCommand
            {
                pgd = pgd
            });
        }

        [Route("collection")]
        [HttpPost]
        public async Task<ActionResult<int>> PostGate([FromBody] List<PostGateDto> PostGateDtos)
        {
            return await _mediator.Send(new PostGateListCommand
            {
                PostGateDtos = PostGateDtos
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> PutGate(int id, [FromBody] PostGateDto pgd)
        {
            return await _mediator.Send(new PutGateCommand
            {
                Id = id,
                pgd = pgd
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteGate(int id)
        {
            return await _mediator.Send(new DeleteGateCommand() { Id = id });
        }

        // TODO: This is very unsafe...security needs to be enabled, could also just drop the database potentially and start anew
        [Route("deleteAll")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAllGates()
        {
            return Ok(await _mediator.Send(new DeleteAllGatesCommand()));
        }
    }
}
