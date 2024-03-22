using Domain.Common.Enum;

namespace Application.ViewModels
{
    public class CandidatesViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public CandidateStatusEnum Status { get; set; }
    }
}
