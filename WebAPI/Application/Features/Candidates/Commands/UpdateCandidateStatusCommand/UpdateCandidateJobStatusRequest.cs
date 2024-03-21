using Domain.Common.Enum;
using MediatR;

namespace Application.Features.Candidates.Commands.UpdateCandidateStatusCommand
{
    public class UpdateCandidateJobStatusRequest : IRequest<UpdateCandidateJobStatusResponse>
    {
        public Guid Id { get; set; }
        public CandidateJobStatusEnum Status { get; set; }
    }
}
