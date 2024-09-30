using FlightBookingApp.Shared.Models;
using FlightBookingApp.Data.Repositories;
using FlightBookingApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FlightBookingApp.Services.DTOs;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;

namespace FlightBookingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, IUserRepository userRepository, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                _logger.LogInformation("User found with email: {Email}", model.Email);
                if (VerifyPasswordHash(model.Password, user.Password, user.PasswordSalt))
                {
                    var token = GenerateJwtToken(user.Email);
                    return Ok(new { Token = token });
                }
                else
                {
                    _logger.LogWarning("Password verification failed for user: {Email}", model.Email);
                }
            }
            else
            {
                _logger.LogWarning("No user found with email: {Email}", model.Email);
            }

            return Unauthorized("Invalid email or password.");
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            var existingUser = await _userRepository.GetUserByEmail(model.Email);
            if (existingUser != null)
            {
                return BadRequest("User already exists.");
            }

            CreatePasswordHash(model.Password, out string passwordHash, out string passwordSalt);

            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                PhoneNumber = model.PhoneNumber
            };

            await _userRepository.AddUserAsync(user);
            return Ok("User registered successfully.");
        }


        private string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, username) },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordHash = Convert.ToBase64String(hash);
            }
        }


        private bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            using (var hmac = new HMACSHA512(Convert.FromBase64String(storedSalt)))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var computedHashString = Convert.ToBase64String(computedHash);
                _logger.LogInformation("Computed Hash: {ComputedHash}", computedHashString);
                _logger.LogInformation("Stored Hash: {StoredHash}", storedHash);
                return computedHashString == storedHash;
            }
        }

    }
}