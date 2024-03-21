using Application.ViewModels.Input;
using MediatR;

namespace Application.Features.Candidates.Commands.UpdateCandidateCommand
{
    public class UpdateCandidateRequest : IRequest<UpdateCandidateResponse>
    {
        public  UpdateCandidateViewModel Candidate { get; set; }
    }
}
