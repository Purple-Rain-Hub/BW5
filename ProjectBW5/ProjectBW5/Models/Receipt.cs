using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBW5.Models
{
    public class Receipt
    {
        [Required]
        public Guid MedicineId { get; set; }

        [ForeignKey(nameof(MedicineId))]
        public Medicine Medicine { get; set; }

        [Required]
        public Guid SaleId { get; set; }

        [ForeignKey(nameof(SaleId))]
        public Sale Sale { get; set; }

        [Required]
        public required string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Required]
        public required int Quantity { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}
