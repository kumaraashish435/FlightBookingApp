using System;
using System.Collections.Generic;
using System.Text;

namespace FlightBookingApp.Shared.Models
{
    public class FlightSearchModel
    {
        public string StartLocation { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; } // Nullable for one-way trips
        public int NumberOfPassengers { get; set; }
        public string Class { get; set; } // e.g., Economy, Business
    }
}
