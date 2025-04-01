namespace ProjectBW5.DTOs.StrayHospital
{
    public class GetStrayHospitalResponseDto
    {
        public required string Message { get; set; }
        public required List<GetStrayHospitalRequestDto>? StrayHospitals { get; set; }
    }
}
