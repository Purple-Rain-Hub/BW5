namespace ProjectBW5.DTOs.Account
{
    public class GetUserResponseDto
    {
        public required string Message { get; set; }
        public required List<UsersDto>? Users { get; set; }
    }
}
