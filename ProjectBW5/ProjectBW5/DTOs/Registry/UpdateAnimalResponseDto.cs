using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Registry
{
    public class UpdateAnimalResponseDto
    {
        [Required]
        public required string Message { get; set; }

    }
}
