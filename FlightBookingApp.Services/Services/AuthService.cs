using FlightBookingApp.Data.Models;
using FlightBookingApp.Data.Repositories;
using FlightBookingApp.Services.DTOs;
using FlightBookingApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace FlightBookingApp.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginUserDto model)
        {
            var user = await _authRepository.GetUserByEmailAsync(model.Email);
            if (user != null && user.Password == model.Password) // Use proper password hashing in real applications
            {
                return GenerateJwtToken(user.Email);
            }
            return null;
        }

        public async Task<bool> RegisterAsync(RegisterUserDto model)
        {

            var user = new User { Email = model.Email, Password = model.Password }; // Use proper password hashing in real applications
            return await _authRepository.RegisterUserAsync(user);
        }

        private string GenerateJwtToken(string email)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, email) },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task LogoutAsync()
        {
            // Implement logout logic here
            throw new NotImplementedException();
        }

        public Task ValidateUserAsync(string username, string password)
        {
            // Implement user validation logic here
            throw new NotImplementedException();
        }

        
    }
}