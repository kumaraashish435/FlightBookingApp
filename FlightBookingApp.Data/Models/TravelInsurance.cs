using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Models
{
    public class TravelInsurance
    {
        public int Id { get; set; }                   // Unique identifier
        public string InsuranceProvider { get; set; } // Insurance company name
        public decimal InsuranceAmount { get; set; }  // Insurance fee
        public string PolicyDetails { get; set; }     // Details of the insurance policy
    }

}
