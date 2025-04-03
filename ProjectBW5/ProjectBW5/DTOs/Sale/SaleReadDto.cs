namespace ProjectBW5.DTOs.Sale
{
    public class SaleReadDto
    {
        public Guid Id { get; set; }
        public string CustomerFiscalCode { get; set; }
        public DateTime SaleDate { get; set; }
        public string? PrescriptionNumber { get; set; }
    }
}
