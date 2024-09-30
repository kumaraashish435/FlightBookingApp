using FlightBookingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Services.Interfaces
{
    // IFlightService.cs
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task<Flight> GetFlightByIdAsync(int id);
        Task<IEnumerable<Flight>> SearchFlights(string startLocation, string destination, DateTime date, int passengers, string tripType);
        Task<IEnumerable<Flight>> FilterFlights(int stops, DateTime departureTime, DateTime arrivalTime);
        Task<IEnumerable<Flight>> GetRecommendedFlights(string preference);
    }
}
