using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.Models
{
    public class Medicine
    {
        [Required]
        public required Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public required string SupplierCompany { get; set; }

        [Required]
        public required string UsageList { get; set; }

        [Required]
        public required string StorageLocationId { get; set; }

        [Required]
        public required bool RequiresPrescription { get; set; }

        [Required]
        [Range(1.00, 9999.99, ErrorMessage = "Price must be greater than 1.")]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
