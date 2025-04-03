namespace ProjectBW5.DTOs.StrayHospital
{
    public class GetStrayHospitalRequestDto
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public required string Type { get; set; }
        public required string CoatColor { get; set; }
        public required bool HasMicrochip { get; set; }
        public int? MicrochipNumber { get; set; }
        public required Guid AnimalId { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required string VetId { get; set; }
        public required string VetName { get; set; }
    }
}
