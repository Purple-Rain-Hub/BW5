using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.StrayHospital
{
    public class CreateStrayHospitalDto
    {

        [Required]
        public required Guid AnimalId { get; set; }
        [Required]
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public required string VetId { get; set; }
    }
}
