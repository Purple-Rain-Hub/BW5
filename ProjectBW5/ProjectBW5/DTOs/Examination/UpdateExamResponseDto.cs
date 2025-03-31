using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Examination
{
    public class UpdateExamResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
