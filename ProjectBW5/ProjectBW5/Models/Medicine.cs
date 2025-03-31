using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.Models
{
    public class Medicine
    {
        [Required]
        public required Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string SupplierCompany { get; set; }

        [Required]
        public required string UsageList { get; set; }

        [Required]
        public required string StorageLocationId { get; set; }

        [Required]
        public required bool RequiresPrescription { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
