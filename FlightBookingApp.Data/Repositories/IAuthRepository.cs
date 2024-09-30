using FlightBookingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    public interface IAuthRepository
    {
        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The user with the specified email address, or null if not found.</returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        /// Registers a new user in the database.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <returns>True if the user was successfully registered; otherwise, false.</returns>
        Task<bool> RegisterUserAsync(User user);

        // Other methods as needed
    }
}
