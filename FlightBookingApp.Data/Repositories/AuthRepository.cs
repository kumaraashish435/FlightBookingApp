using FlightBookingApp.Data.Context;
using FlightBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    /// <summary>
    /// Repository for handling authentication-related database operations.
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The user with the specified email address, or null if not found.</returns>
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// Registers a new user in the database.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <returns>True if the user was successfully registered; otherwise, false.</returns>
        public async Task<bool> RegisterUserAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        // Other methods as needed
    }
}