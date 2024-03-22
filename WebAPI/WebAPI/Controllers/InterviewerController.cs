using Application.Features.Interviewers.Queries.GetInterviewersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InterviewerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<InterviewerController> _logger;
        public InterviewerController(IMediator mediator, ILogger<InterviewerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetInterviewersAsync")]
        [Route("interviewers")]
        public async Task<IActionResult> GetInterviewersAsync(CancellationToken token)
        {
            var response = await _mediator.Send(new GetInterviewersRequest(), token);
            return Ok(response);
        }
    }
}
