using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Receipt
{
    public class ReceiptDeleteDto
    {
        [Required]
        public Guid MedicineId { get; set; }

        [Required]
        public Guid SaleId { get; set; }
    }
}
