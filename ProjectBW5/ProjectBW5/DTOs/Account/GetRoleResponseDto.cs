﻿namespace ProjectBW5.DTOs.Account
{
    public class GetRoleResponseDto
    {
        public required string Message { get; set; }
        public required List<RolesDto>? Roles { get; set; }

    }
}
