using FlightBookingApp.Data.Repositories;
using FlightBookingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Services.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<IEnumerable<Passenger>> GetPassengersAsync()
        {
            return await _passengerRepository.GetPassengersAsync();
        }

        public async Task<Passenger> GetPassengerByIdAsync(int id)
        {
            return await _passengerRepository.GetPassengerByIdAsync(id);
        }

        public async Task AddPassengerAsync(Passenger passenger)
        {
            await _passengerRepository.AddPassengerAsync(passenger);
        }

        public async Task UpdatePassengerAsync(Passenger passenger)
        {
            await _passengerRepository.UpdatePassengerAsync(passenger);
        }

        public async Task DeletePassengerAsync(int id)
        {
            await _passengerRepository.DeletePassengerAsync(id);
        }
    }
}
