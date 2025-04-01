namespace ProjectBW5.DTOs.StrayHospital
{
    public class GetStrayHospitalByMicrochipRequestDto
    {
        public required string Type { get; set; }
        public required string CoatColor { get; set; }
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required string VetName { get; set; }
    }
}
