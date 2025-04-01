namespace ProjectBW5.DTOs.Hospitalization
{
    public class GetHospitalResponseDto
    {
        public required string Message { get; set; }
        public required List<GetHospitalRequestDto>? Hospitals { get; set; }
    }
}
