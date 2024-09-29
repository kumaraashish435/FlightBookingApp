using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    // IPassengerRepository.cs
    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> GetPassengersAsync();
        Task<Passenger> GetPassengerByIdAsync(int id);
        Task AddPassengerAsync(Passenger passenger);
        Task UpdatePassengerAsync(Passenger passenger);
        Task DeletePassengerAsync(int id);
    }
}
