namespace ProjectBW5.DTOs.Hospitalization
{
    public class GetHospitalRequestDto
    {
        public Guid Id { get; set; }
        public required Guid AnimalId { get; set; }
        public required string AnimalName { get; set; }
        public required string OwnerName { get; set; }
        public required string OwnerSurname { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required string HospitalObjective { get; set; }
        public required string HospitalTreatment { get; set; }
        public required string VetId { get; set; }
        public required string VetName {  get; set; }
    }
}
