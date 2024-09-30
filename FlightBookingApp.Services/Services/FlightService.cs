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

        public async Task<IEnumerable<Flight>> SearchFlights(string startLocation, string destination, DateTime date, int passengers, string tripType)
        {
            return await _flightRepository.SearchFlights(startLocation, destination, date, passengers, tripType);
        }

        public async Task<IEnumerable<Flight>> FilterFlights(int stops, DateTime departureTime, DateTime arrivalTime)
        {
            return await _flightRepository.FilterFlights(stops, departureTime, arrivalTime);
        }

        public async Task<IEnumerable<Flight>> GetRecommendedFlights(string preference)
        {
            return await _flightRepository.GetRecommendedFlights(preference);
        }
    }
}
