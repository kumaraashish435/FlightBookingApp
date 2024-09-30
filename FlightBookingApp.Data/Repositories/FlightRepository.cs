using FlightBookingApp.Data.Context;
using FlightBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<Flight?> GetFlightByIdAsync(int id)
        {
            return await _context.Flights.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Flight>> SearchFlights(string startLocation, string destination, DateTime date, int passengers, string tripType)
        {
            return await _context.Flights
                .Where(f => f.StartLocation == startLocation
                         && f.Destination == destination
                         && f.DepartureTime.Date == date.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Flight>> FilterFlights(int stops, DateTime departureTime, DateTime arrivalTime)
        {
            return await _context.Flights
                .Where(f => f.NumberOfStops == stops
                         && f.DepartureTime >= departureTime
                         && f.ArrivalTime <= arrivalTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Flight>> GetRecommendedFlights(string preference)
        {
            if (preference == "cheapest")
            {
                return await _context.Flights.OrderBy(f => f.Fare).Take(5).ToListAsync();
            }
            else if (preference == "best-time")
            {
                return await _context.Flights.OrderBy(f => f.DepartureTime).Take(5).ToListAsync();
            }

            return Enumerable.Empty<Flight>();
        }
    }
}