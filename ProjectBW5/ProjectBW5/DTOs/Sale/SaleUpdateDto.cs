using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Sale
{
    public class SaleUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string CustomerFiscalCode { get; set; }

        public string? PrescriptionNumber { get; set; }
    }
}
