using FlightBookingApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBookingApp.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task<bool> ProcessPaymentAsync(Payment payment);
        Task<bool> ApplyOfferAsync(int bookingId, string offerCode);
        Task<bool> AddInsuranceAsync(int bookingId, TravelInsurance insurance);
        Task UpdatePaymentAsync(Payment payment);
    }
}