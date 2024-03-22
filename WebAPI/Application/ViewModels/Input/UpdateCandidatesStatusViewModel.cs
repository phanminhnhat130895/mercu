using Domain.Common.Enum;

namespace Application.ViewModels.Input
{
    public class UpdateCandidatesStatusViewModel
    {
        public Guid Id { get; set; }
        public CandidateStatusEnum Status { get; set; }
    }
}
