using ProjectBW5.DTOs.Artist;

namespace ProjectBW5.DTOs.Animal
{
    public class GetAnimalResponseDto
    {
        public required string Message { get; set; }
        public required List<GetAnimalRequestDto>? Animals { get; set; }
    }
}
