using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.StrayHospital
{
    public class CreateStrayHospitalDto
    {
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
    }
}
