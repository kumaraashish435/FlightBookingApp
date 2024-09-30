using FlightBookingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task<bool> ProcessPaymentAsync(Payment payment); // Process a payment
        Task<bool> ApplyOfferAsync(int bookingId, string offerCode); // Apply a discount offer
        Task<bool> AddInsuranceAsync(int bookingId, TravelInsurance insurance); // Add travel insurance
        Task UpdatePaymentAsync(Payment payment);
        
    }
}
