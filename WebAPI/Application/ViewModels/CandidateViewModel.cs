using Domain.Common.Enum;

namespace Application.ViewModels
{
    public class CandidateViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<CandidateJobViewModel> Jobs { get; set; }
    }

    public class CandidateJobViewModel
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public Guid InterviewerId { get; set; }
        public CandidateJobStatusEnum Status { get; set; }
    }
}
