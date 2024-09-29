using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Models
{
    public class Refund
    {
        public int Id { get; set; }                   // Unique identifier
        public int BookingId { get; set; }            // Foreign key for the related booking
        public Booking Booking { get; set; }          // Navigation property to Booking
        public decimal RefundAmount { get; set; }     // Refund amount
        public DateTime RefundDate { get; set; }      // Date when refund was processed
        public string RefundStatus { get; set; }      // Status of the refund (e.g., Processed, Pending)
    }

}
