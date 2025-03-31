using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectBW5.Models;
using ProjectBW5.Settings;
using ProjectBW5.DTOs.Account;
using ProjectBW5.Services;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace ProjectBW5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _accountService.GetRolesAsync();

                if (roles == null)
                {
                    return BadRequest(new
                    {
                        message = "Something went wrong"
                    });
                }

                var count = roles.Count();

                var text = count == 1 ? $"{count} role found" : $"{count} roles found";

                return Ok(new
                GetRoleResponseDto()
                {
                    Message = text,
                    Roles = roles
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
        {
            var success = await _accountService.RegisterAsync(registerRequest);
            if (success)
            {
                return Ok(new { message = "Account successfully registered!" });
            }
            else
            {
                return BadRequest(new { message = "Email is already registered or something went wrong." });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var (success, result) = await _accountService.LoginAsync(loginRequest);

            if (success)
            {
                return Ok(new { token = result });
            }
            else
            {
                return Unauthorized(new { message = result });
            }
        }
    }
}
