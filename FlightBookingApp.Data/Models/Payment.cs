using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }                   // Unique identifier
        public int BookingId { get; set; }            // Foreign key for the related booking
        public Booking Booking { get; set; }          // Navigation property to Booking
        public decimal Amount { get; set; }           // Payment amount
        public DateTime PaymentDate { get; set; }     // Date of payment
        public string PaymentMode { get; set; }       // Payment mode (e.g., UPI, Credit Card, Debit Card)
        public string PaymentStatus { get; set; }     // Status (e.g., Completed, Failed, Pending)
    }

}
