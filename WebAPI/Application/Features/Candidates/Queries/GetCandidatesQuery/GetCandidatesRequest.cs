using MediatR;

namespace Application.Features.Candidates.Queries.GetAllCandidateQuery
{
    public class GetCandidatesRequest : IRequest<GetCandidatesResponse>
    {
        public string SearchString { get; set; }

        public DateTime? SearchDate { get; set; }

        public Guid? InterviewerId { get; set; }
    }
}
