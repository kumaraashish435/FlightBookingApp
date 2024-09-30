using System;
using System.Collections.Generic;
using System.Text;

namespace FlightBookingApp.Shared.Models
{
    public class AuthenticationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
