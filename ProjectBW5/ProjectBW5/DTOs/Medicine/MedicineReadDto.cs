namespace ProjectBW5.DTOs.Medicine
{
    public class MedicineReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SupplierCompany { get; set; }
        public string UsageList { get; set; }
        public string StorageLocationId { get; set; }
        public bool RequiresPrescription { get; set; }
    }
}