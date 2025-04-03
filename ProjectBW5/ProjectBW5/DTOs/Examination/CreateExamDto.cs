using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Examination
{
    public class CreateExamDto
    {
        [Required]
        public required DateTime ExamDate { get; set; }
        [Required]
        [MaxLength(500)]
        public required string ExamObjective { get; set; }
        [Required]
        [MaxLength(500)]
        public required string ExamTreatment { get; set; }
        [Required]
        public required string VetId { get; set; }
    }
}
