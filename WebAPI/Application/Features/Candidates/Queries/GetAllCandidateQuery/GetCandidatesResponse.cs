using Application.ViewModels;

namespace Application.Features.Candidates.Queries.GetAllCandidateQuery
{
    public class GetCandidatesResponse
    {
        public List<CandidatesViewModel> Candidates { get; set; }
    }
}
