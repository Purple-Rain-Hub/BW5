using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Registry
{
    public class CreateAnimalDto
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Type { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CoatColor { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        public required bool HasMicrochip { get; set; }
        public int? MicrochipNumber { get; set; }
        [MaxLength(50)]
        public string? OwnerName { get; set; }
        [MaxLength(50)]
        public string? OwnerSurname { get; set; }
    }
}
