using Application.ViewModels;

namespace Application.Features.Candidates.Queries.GetAllCandidateQuery
{
    public class GetCandidatesResponse
    {
        public List<CandidateViewModel> Candidates { get; set; }
    }
}
