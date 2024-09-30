using FlightBookingApp.Data.Context;
using FlightBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.Passengers)
                .Include(b => b.Flight)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Booking> CancelBookingAsync(int bookingId)
        {
            var booking = await GetBookingByIdAsync(bookingId);
            if (booking != null)
            {
                booking.BookingStatus = "Canceled";
                await _context.SaveChangesAsync();
            }
            return booking;
        }

        public async Task<IEnumerable<Booking>> GetBookedFlightsAsync(string email)
        {
            return await _context.Bookings
                .Include(b => b.Passengers)
                .Include(b => b.Flight)
                .Where(b => b.Passengers.Any(p => p.Email == email) && b.BookingStatus == "Confirmed")
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetCancelledFlightsAsync(string email)
        {
            return await _context.Bookings
                .Include(b => b.Passengers)
                .Include(b => b.Flight)
                .Where(b => b.Passengers.Any(p => p.Email == email) && b.BookingStatus == "Canceled")
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetRefundedFlightsAsync(string email)
        {
            return await _context.Bookings
                .Include(b => b.Passengers)
                .Include(b => b.Flight)
                .Where(b => b.Passengers.Any(p => p.Email == email) && b.BookingStatus == "Refunded")
                .ToListAsync();
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}