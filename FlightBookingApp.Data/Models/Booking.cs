using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }                   // Unique identifier
        public int FlightId { get; set; }             // Foreign key for the related flight
        public Flight Flight { get; set; }            // Navigation property to Flight
        public DateTime BookingDate { get; set; }     // Date when the booking was made
        public string BookingStatus { get; set; }     // Status (e.g., Confirmed, Canceled)

        public ICollection<Passenger> Passengers { get; set; }  // Passengers for the booking
    }

}
