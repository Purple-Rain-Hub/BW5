using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Receipt
{
    public class ReceiptCreateDto
    {
        [Required]
        public Guid MedicineId { get; set; }

        [Required]
        public Guid SaleId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
