using ProjectBW5.DTOs.Registry;

namespace ProjectBW5.DTOs.Registry
{
    public class GetAnimalResponseDto
    {
        public required string Message { get; set; }
        public required List<GetAnimalRequestDto>? Animals { get; set; }
    }
}
