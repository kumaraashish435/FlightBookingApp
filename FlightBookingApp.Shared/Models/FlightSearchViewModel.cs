using System;
using System.Collections.Generic;
using System.Text;

namespace FlightBookingApp.Shared.Models
{
    public class FlightSearchViewModel
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
