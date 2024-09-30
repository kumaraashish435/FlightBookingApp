using FlightBookingApp.Data.Models;
using FlightBookingApp.Data.Repositories;
using FlightBookingApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBookingApp.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _bookingRepository.GetBookingByIdAsync(id);
        }

        public async Task<Booking> CancelBookingAsync(int bookingId)
        {
            return await _bookingRepository.CancelBookingAsync(bookingId);
        }

        public async Task<IEnumerable<Booking>> GetBookedFlightsAsync(string email)
        {
            return await _bookingRepository.GetBookedFlightsAsync(email);
        }

        public async Task<IEnumerable<Booking>> GetCancelledFlightsAsync(string email)
        {
            return await _bookingRepository.GetCancelledFlightsAsync(email);
        }

        public async Task<IEnumerable<Booking>> GetRefundedFlightsAsync(string email)
        {
            return await _bookingRepository.GetRefundedFlightsAsync(email);
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            await _bookingRepository.UpdateBookingAsync(booking);
        }
    }
}