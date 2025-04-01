using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Medicine
{
    public class MedicineUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string StorageLocationId { get; set; }

        [Required]
        public bool RequiresPrescription { get; set; }

        [Required]
        [Range(1.00, 9999.99)]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
