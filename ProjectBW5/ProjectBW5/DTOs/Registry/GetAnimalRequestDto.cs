using ProjectBW5.DTOs.Registry;
using ProjectBW5.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.DTOs.Artist
{
    public class GetAnimalRequestDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string CoatColor { get; set; }
        public DateOnly BirthDate { get; set; }
        public required bool HasMicrochip { get; set; }
        public int? MicrochipNumber { get; set; }
        public required string OwnerName { get; set; }
        public required string OwnerSurname { get; set; }
    }
}
