using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.Models
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Type { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CoatColor { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        public required bool HasMicrochip { get; set; }
        public int? MicrochipNumber { get; set; }
        [MaxLength (50)]
        public string? OwnerName { get; set; }
        [MaxLength (50)]
        public string? OwnerSurname { get; set; }

        public ICollection<Examination>? Examinations { get; set; }
        public ICollection<Hospitalization>? Hospitalizations { get; set; }
        public StrayHospital? StrayHospital { get; set; }

    }
}
