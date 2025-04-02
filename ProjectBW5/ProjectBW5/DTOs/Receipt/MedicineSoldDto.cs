namespace ProjectBW5.DTOs.Receipt
{
    public class MedicineSoldDto
    {
        public Guid MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public DateTime Timestamp { get; set; }
        public string CustomerFiscalCode { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
