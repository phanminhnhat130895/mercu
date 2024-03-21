using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
