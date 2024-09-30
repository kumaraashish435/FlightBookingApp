using FlightBookingApp.Data.Models;
using FlightBookingApp.Data.Repositories;
using FlightBookingApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBookingApp.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await _paymentRepository.GetPaymentsAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _paymentRepository.GetPaymentByIdAsync(id);
        }

        public async Task<bool> ProcessPaymentAsync(Payment payment)
        {
            return await _paymentRepository.ProcessPaymentAsync(payment);
        }

        public async Task<bool> ApplyOfferAsync(int bookingId, string offerCode)
        {
            return await _paymentRepository.ApplyOfferAsync(bookingId, offerCode);
        }

        public async Task<bool> AddInsuranceAsync(int bookingId, TravelInsurance insurance)
        {
            return await _paymentRepository.AddInsuranceAsync(bookingId, insurance);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _paymentRepository.UpdatePaymentAsync(payment);
        }
    }
}