namespace ProjectBW5.DTOs.Examination
{
    public class GetExamResponseDto
    {
        public required string Message { get; set; }
        public required List<GetExamRequestDto>? Exams { get; set; }
    }
}
