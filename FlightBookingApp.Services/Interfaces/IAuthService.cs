using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBookingApp.Services.DTOs;

namespace FlightBookingApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginUserDto model);
        Task<bool> RegisterAsync(RegisterUserDto model);
        // Other methods as needed
        Task LogoutAsync();
        Task ValidateUserAsync(string username, string password);
        
    }
}
