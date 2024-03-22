using Domain.Common;
using Domain.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CandidateJob : Entity
    {
        public CandidateJob(Guid id) : base(id)
        {
        }

        [Required]
        [MaxLength(36)]
        public Guid JobId { get; set; }
        [Required]
        [MaxLength(36)]
        public Guid CandidateId { get; set; }
        [Required]
        [MaxLength(36)]
        public Guid InterviewerId { get; set; }

        public Job Job { get; set; }
        public Candidate Candidate { get; set; }
        public Interviewer Interviewer { get; set; }
    }
}
