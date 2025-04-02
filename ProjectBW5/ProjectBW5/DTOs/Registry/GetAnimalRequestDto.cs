namespace ProjectBW5.DTOs.Registry
{
    public class GetAnimalRequestDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public required string Type { get; set; }
        public required string CoatColor { get; set; }
        public DateTime? BirthDate { get; set; }
        public required bool HasMicrochip { get; set; }
        public int? MicrochipNumber { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerSurname { get; set; }
    }
}
