using MediatR;

namespace Application.Features.Candidates.Queries.GetCandidateByIdQuery
{
    public class GetCandidateByIdRequest : IRequest<GetCandidateByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
