using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBW5.Models
{
    public class Hospitalization
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public required Guid AnimalId { get; set; }
        [ForeignKey("AnimalId")]
        public Animal Animal { get; set; }
        [Required]
        public required DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(500)]
        public required string HospitalObjective { get; set; }
        [Required]
        [MaxLength(500)]
        public required string HospitalTreatment { get; set; }
        [Required]
        public required string VetId { get; set; }
        [ForeignKey("VetId")]
        public ApplicationUser User { get; set; }
    }
}
