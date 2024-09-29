using FlightBookingApp.Data.Context;
using FlightBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    public class TravelInsuranceRepository : ITravelInsuranceRepository
    {
        private readonly ApplicationDbContext _context;

        public TravelInsuranceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TravelInsurance>> GetTravelInsurancesAsync()
        {
            return await _context.TravelInsurances.ToListAsync();
        }

        public async Task<TravelInsurance> GetTravelInsuranceByIdAsync(int id)
        {
            return await _context.TravelInsurances.FindAsync(id);
        }

        public async Task AddTravelInsuranceAsync(TravelInsurance travelInsurance)
        {
            await _context.TravelInsurances.AddAsync(travelInsurance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTravelInsuranceAsync(TravelInsurance travelInsurance)
        {
            _context.TravelInsurances.Update(travelInsurance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTravelInsuranceAsync(int id)
        {
            var travelInsurance = await _context.TravelInsurances.FindAsync(id);
            if (travelInsurance != null)
            {
                _context.TravelInsurances.Remove(travelInsurance);
                await _context.SaveChangesAsync();
            }
        }
    }
}
