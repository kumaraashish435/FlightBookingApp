using FlightBookingApp.Data.Context;
using FlightBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await _context.Payments
                .Include(p => p.Booking)
                .ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Booking)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> ProcessPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ApplyOfferAsync(int bookingId, string offerCode)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return false;

            // Apply offer logic here (e.g., update booking price)
            // For simplicity, let's assume the offer reduces the fare by 10%
            booking.Flight.Fare *= 0.9m;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddInsuranceAsync(int bookingId, TravelInsurance insurance)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return false;

            await _context.TravelInsurances.AddAsync(insurance);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }
    }
}