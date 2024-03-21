using Domain.Common;
using Domain.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Job : Entity
    {
        public Job(Guid id) : base(id)
        {
        }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime ExpiredDate { get; set; }
        public JobStatusEnum Status { get; set; }
    }
}
