using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Hospitalization
{
    public class UpdateHospitalResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
