using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }                   // Unique identifier
        public int BookingId { get; set; }            // Foreign key for the related booking
        public Booking Booking { get; set; }          // Navigation property to Booking
        public string TicketNumber { get; set; }      // Ticket number
        public DateTime IssuedDate { get; set; }      // Date the ticket was issued
    }

}
