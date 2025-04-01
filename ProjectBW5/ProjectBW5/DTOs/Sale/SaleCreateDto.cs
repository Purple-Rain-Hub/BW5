using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Sale
{
    public class SaleCreateDto
    {
        [Required]
        public string CustomerFiscalCode { get; set; }

        public string? PrescriptionNumber { get; set; }
    }
}
