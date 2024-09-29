using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Models
{
    public class User
    {
        public int Id { get; set; }                   // Unique identifier
        public string UserName { get; set; }          // Username for login
        public string Email { get; set; }             // Email for login
        public string PasswordHash { get; set; }
    }

}
