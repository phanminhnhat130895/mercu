using Application.ViewModels.Input;
using MediatR;

namespace Application.Features.Candidates.Commands.UpdateCandidateStatusCommand
{
    public class UpdateCandidateStatusRequest : IRequest<UpdateCandidateStatusResponse>
    {
        public List<UpdateCandidatesStatusViewModel> Data { get; set; }
    }
}
