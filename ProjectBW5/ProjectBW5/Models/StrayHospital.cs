using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBW5.Models
{
    public class StrayHospital
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Type { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CoatColor { get; set; }
        [Required]
        public required bool HasMicrochip { get; set; }
        public int? MicrochipNumber { get; set; }
        [Required]
        [MaxLength(1000)]
        public required string Description { get; set; }
        [Required]
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public required string VetId { get; set; }
        [ForeignKey("VetId")]
        public ApplicationUser User { get; set; }
    }
}
