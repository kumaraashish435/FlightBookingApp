using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Models
{
    public class Offer
    {
        public int Id { get; set; }                   // Unique identifier
        public string OfferCode { get; set; } = string.Empty; // Offer code (e.g., SUMMER20)
        public string Description { get; set; }       // Offer description
        public decimal DiscountAmount { get; set; }   // Discount amount
        public DateTime ValidFrom { get; set; }       // Offer validity start date
        public DateTime ValidUntil { get; set; }      // Offer validity end date
    }
}