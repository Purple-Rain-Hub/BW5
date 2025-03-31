using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Registry
{
    public class CreateAnimalDto
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Type { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CoatColor { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public required bool HasMicrochip { get; set; }
        public int? MicrochipNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public required string OwnerName { get; set; }
        [Required]
        [MaxLength(50)]
        public required string OwnerSurname { get; set; }
    }
}
