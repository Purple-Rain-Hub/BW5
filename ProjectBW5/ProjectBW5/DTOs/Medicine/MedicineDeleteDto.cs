using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Medicine
{
    public class MedicineDeleteDto
    {
        [Required]
        public Guid Id { get; set; }
    }
}