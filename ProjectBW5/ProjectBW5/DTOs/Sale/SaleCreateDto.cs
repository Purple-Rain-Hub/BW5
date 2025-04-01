using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Sale
{
    public class SaleCreateDto
    {
        [Required(ErrorMessage = "Customer fiscal code is required.")]
        [MaxLength(16)]
        [RegularExpression(@"^[A-Z]{6}[0-9]{2}[A-Z][0-9]{2}[A-Z][0-9]{3}[A-Z]$",
            ErrorMessage = "Invalid fiscal code format.")]
        public string CustomerFiscalCode { get; set; }

        [MaxLength(20)]
        [RegularExpression(@"^\d{8,20}$",
            ErrorMessage = "Prescription number must contain only digits (8 to 20 characters).")]
        public string? PrescriptionNumber { get; set; }
    }
}
