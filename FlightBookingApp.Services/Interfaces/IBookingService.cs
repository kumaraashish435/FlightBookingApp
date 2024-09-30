using FlightBookingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> CancelBookingAsync(int bookingId);
        Task<IEnumerable<Booking>> GetBookedFlightsAsync(string email);
        Task<IEnumerable<Booking>> GetCancelledFlightsAsync(string email);
        Task<IEnumerable<Booking>> GetRefundedFlightsAsync(string email);
        Task UpdateBookingAsync(Booking booking);
    }
}
