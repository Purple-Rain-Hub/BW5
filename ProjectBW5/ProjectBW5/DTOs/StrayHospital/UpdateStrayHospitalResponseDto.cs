using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.StrayHospital
{
    public class UpdateStrayHospitalResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
