using FlightBookingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    // IBookingRepository.cs
    public interface IBookingRepository
    {
        
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> CancelBookingAsync(int bookingId); // Cancels a flight
        Task<IEnumerable<Booking>> GetBookedFlightsAsync(string email); // Gets booked flights by user's email
        Task<IEnumerable<Booking>> GetCancelledFlightsAsync(string email); // Gets cancelled flights by user's email
        Task<IEnumerable<Booking>> GetRefundedFlightsAsync(string email); // Gets refunded flights by user's email
        Task UpdateBookingAsync(Booking booking);
        
    }
}
