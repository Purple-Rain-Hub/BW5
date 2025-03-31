using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.Models
{
    public class Sale
    {
        [Required]
        public required Guid Id { get; set; }

        [Required]
        public required string CustomerFiscalCode { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        public string? PrescriptionNumber { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
