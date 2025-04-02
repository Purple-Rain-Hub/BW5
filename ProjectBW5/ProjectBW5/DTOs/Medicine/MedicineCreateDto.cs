using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Medicine
{
    public class MedicineCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string SupplierCompany { get; set; }

        [Required]
        public string UsageList { get; set; }

        [Required]
        public string StorageLocationId { get; set; }

        [Required]
        public bool RequiresPrescription { get; set; }

        [Required]
        [Range(1.00, 9999.99, ErrorMessage = "Price must be greater than 1.")]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
