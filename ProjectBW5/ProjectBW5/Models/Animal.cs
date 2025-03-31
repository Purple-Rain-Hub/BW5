using System.ComponentModel.DataAnnotations;

namespace ProjectBW5.Models
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Type { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CoatColor { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public required bool HasMicrochip { get; set; }
        public int? MicrochipNumber { get; set; }
        [Required]
        [MaxLength (50)]
        public required string OwnerName { get; set; }
        [Required]
        [MaxLength (50)]
        public required string OwnerSurname { get; set; }

        public ICollection<Examination>? Examinations { get; set; }
        public ICollection<Hospitalization>? Hospitalizations { get; set; }

    }
}
