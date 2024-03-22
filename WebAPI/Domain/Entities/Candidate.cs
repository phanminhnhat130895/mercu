using Domain.Common;
using Domain.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Candidate : Entity
    {
        public Candidate(Guid id) : base(id)
        {
        }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        public CandidateStatusEnum Status { get; set; }

        public ICollection<CandidateJob> Jobs { get; set; }
    }
}
