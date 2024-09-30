using System;
using System.Collections.Generic;
using System.Text;

namespace FlightBookingApp.Shared.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
    }
}