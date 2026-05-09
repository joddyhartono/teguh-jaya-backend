using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeguhJaya.Api.Interfaces;
using TeguhJaya.Api.Models;
using TeguhJaya.Api.Services;

namespace TeguhJaya.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(ILogger<AuthController> logger, IUserRepository repository, JwtService jwtService)
        {
            _logger = logger;
            _repository = repository;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] User request)
        {
            _logger.LogInformation("Login started");
            try
            {
                var user = _repository.GetUser(request.Username);
                
                if(user == null)
                {
                    return Unauthorized("Username atau password salah.");
                }
                
                var isPasswordValid = PasswordService.VerifyPassword(request.Password, user.Password);

                if(!isPasswordValid)
                {
                    return Unauthorized("Username atau password salah.");
                }

                var token = _jwtService.GenerateToken(user);
                
                _logger.LogInformation("Login finished successfully");
                return Ok(new
                {
                    Id = user.Id,
                    Username = user.Username,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while logging in");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}