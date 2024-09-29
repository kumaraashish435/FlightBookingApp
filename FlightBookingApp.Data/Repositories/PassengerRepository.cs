using FlightBookingApp.Data.Context;

using Microsoft.EntityFrameworkCore;


namespace FlightBookingApp.Data.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDbContext _context;

        public PassengerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Passenger>> GetPassengersAsync()
        {
            return await _context.Passengers.ToListAsync();
        }

        public async Task<Passenger> GetPassengerByIdAsync(int id)
        {
            return await _context.Passengers.FindAsync(id);
        }

        public async Task AddPassengerAsync(Passenger passenger)
        {
            await _context.Passengers.AddAsync(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePassengerAsync(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePassengerAsync(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                await _context.SaveChangesAsync();
            }
        }
    }
}
