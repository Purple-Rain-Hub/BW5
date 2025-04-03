using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBW5.Models
{
    public class Examination
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public required DateTime ExamDate { get; set; }
        [Required]
        [MaxLength(500)]
        public required string ExamObjective { get; set; }
        [Required]
        [MaxLength(500)]
        public required string ExamTreatment { get; set; }
        [Required]
        public required Guid AnimalId { get; set; }
        [ForeignKey("AnimalId")]
        public Animal Animal { get; set; }
        [Required]
        public required string VetId { get; set; }
        [ForeignKey("VetId")]
        public ApplicationUser User { get; set; }
    }
}
