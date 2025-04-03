namespace ProjectBW5.DTOs.Examination
{
    public class GetExamRequestDto
    {
        public Guid Id { get; set; }
        public required DateTime ExamDate { get; set; }
        public required string ExamObjective { get; set; }
        public required string ExamTreatment { get; set; }
        public required Guid AnimalId { get; set; }
        public required string AnimalName { get; set; }
        public required string OwnerName { get; set; }
        public required string OwnerSurname { get; set; }
        public required string VetId { get; set; }
        public required string VetName { get; set; }
    }
}
