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
    public class TravelInsuranceService : ITravelInsuranceService
    {
        private readonly ITravelInsuranceRepository _travelInsuranceRepository;

        public TravelInsuranceService(ITravelInsuranceRepository travelInsuranceRepository)
        {
            _travelInsuranceRepository = travelInsuranceRepository;
        }

        public async Task<IEnumerable<TravelInsurance>> GetTravelInsurancesAsync()
        {
            return await _travelInsuranceRepository.GetTravelInsurancesAsync();
        }

        public async Task<TravelInsurance> GetTravelInsuranceByIdAsync(int id)
        {
            return await _travelInsuranceRepository.GetTravelInsuranceByIdAsync(id);
        }

        public async Task AddTravelInsuranceAsync(TravelInsurance travelInsurance)
        {
            await _travelInsuranceRepository.AddTravelInsuranceAsync(travelInsurance);
        }

        public async Task UpdateTravelInsuranceAsync(TravelInsurance travelInsurance)
        {
            await _travelInsuranceRepository.UpdateTravelInsuranceAsync(travelInsurance);
        }

        public async Task DeleteTravelInsuranceAsync(int id)
        {
            await _travelInsuranceRepository.DeleteTravelInsuranceAsync(id);
        }
    }
}
