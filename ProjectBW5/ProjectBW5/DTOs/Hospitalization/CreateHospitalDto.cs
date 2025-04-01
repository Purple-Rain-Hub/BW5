using ProjectBW5.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Hospitalization
{
    public class CreateHospitalDto
    {
        [Required]
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        [MaxLength(500)]
        public required string HospitalObjective { get; set; }
        [Required]
        [MaxLength(500)]
        public required string HospitalTreatment { get; set; }
        [Required]
        public required string VetId { get; set; }
    }
}
