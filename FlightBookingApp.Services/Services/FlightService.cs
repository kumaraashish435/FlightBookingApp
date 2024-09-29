using FlightBookingApp.Data.Models;
using FlightBookingApp.Data.Repositories;
using FlightBookingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Services.Services
{
    // FlightService.cs
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync()
        {
            return await _flightRepository.GetFlightsAsync();
        }

        public async Task<Flight> GetFlightByIdAsync(int id)
        {
            return await _flightRepository.GetFlightByIdAsync(id);
        }

        public async Task AddFlightAsync(Flight flight)
        {
            await _flightRepository.AddFlightAsync(flight);
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            await _flightRepository.UpdateFlightAsync(flight);
        }

        public async Task DeleteFlightAsync(int id)
        {
            await _flightRepository.DeleteFlightAsync(id);
        }

        // Implementing methods for new models
        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _flightRepository.GetBookingsAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _flightRepository.GetBookingByIdAsync(id);
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await _flightRepository.AddBookingAsync(booking);
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            await _flightRepository.UpdateBookingAsync(booking);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _flightRepository.DeleteBookingAsync(id);
        }
    }
}
