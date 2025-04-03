using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBW5.Models
{
    public class Sale
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(16)]
        [RegularExpression(@"^[A-Z]{6}[0-9]{2}[A-Z][0-9]{2}[A-Z][0-9]{3}[A-Z]$",
            ErrorMessage = "Invalid fiscal code format.")]
        public string CustomerFiscalCode { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime SaleDate { get; set; }

        [MaxLength(20)]
        [RegularExpression(@"^\d{8,20}$",
            ErrorMessage = "Prescription number must contain only digits (8 to 20 characters).")]
        public string? PrescriptionNumber { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
