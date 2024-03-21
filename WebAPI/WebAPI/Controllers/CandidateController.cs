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
    [Route("[controller]")]
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
        [Route("candidate")]
        public async Task<IActionResult> GetCandidateByIdAsync([FromQuery] Guid id, CancellationToken token)
        {
            var response = await _mediator.Send(new GetCandidateByIdRequest() { Id = id });
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCandidateAsync")]
        [Route("candidate")]
        public async Task<IActionResult> UpdateCandidateAsync([FromBody] UpdateCandidateRequest request, CancellationToken token)
        {
            var response = await _mediator.Send(request, token);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateCandidateJobStatusAsync")]
        [Route("candidate-job-status")]
        public async Task<IActionResult> UpdateCandidateJobStatusAsync([FromQuery] Guid id, [FromQuery] CandidateJobStatusEnum status, CancellationToken token)
        {
            var response = await _mediator.Send(new UpdateCandidateJobStatusRequest() { Id = id, Status = status });
            return Ok(response);
        }
    }
}
