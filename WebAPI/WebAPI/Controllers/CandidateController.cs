using Application.Features.Candidates.Commands.UpdateCandidateCommand;
using Application.Features.Candidates.Commands.UpdateCandidateStatusCommand;
using Application.Features.Candidates.Queries.GetAllCandidateQuery;
using Application.Features.Candidates.Queries.GetCandidateByIdQuery;
using Domain.Common.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly IMediator _mediator;

        public CandidateController(ILogger<CandidateController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCandidatesAsync")]
        [Route("candidates")]
        public async Task<IActionResult> GetCandidatesAsync([FromQuery] GetCandidatesRequest request, CancellationToken token)
        {
            var response = await _mediator.Send(request, token);
            return Ok(response);
        }

        [HttpGet(Name = "GetCandidateByIdAsync")]
        [Route("candidate/{id}")]
        public async Task<IActionResult> GetCandidateByIdAsync([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _mediator.Send(new GetCandidateByIdRequest() { Id = id }, token);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCandidateAsync")]
        [Route("candidate")]
        public async Task<IActionResult> UpdateCandidateAsync([FromBody] UpdateCandidateRequest request, CancellationToken token)
        {
            var response = await _mediator.Send(request, token);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateCandidateStatusAsync")]
        [Route("candidates-status")]
        public async Task<IActionResult> UpdateCandidateStatusAsync([FromBody] UpdateCandidateStatusRequest request, CancellationToken token)
        {
            var response = await _mediator.Send(request, token);
            return Ok(response);
        }
    }
}
