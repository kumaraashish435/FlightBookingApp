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
    public class RefundRepository : IRefundRepository
    {
        private readonly ApplicationDbContext _context;

        public RefundRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Refund>> GetRefundsAsync()
        {
            return await _context.Refunds.ToListAsync();
        }

        public async Task<Refund> GetRefundByIdAsync(int id)
        {
            return await _context.Refunds.FindAsync(id);
        }

        public async Task AddRefundAsync(Refund refund)
        {
            await _context.Refunds.AddAsync(refund);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRefundAsync(Refund refund)
        {
            _context.Refunds.Update(refund);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRefundAsync(int id)
        {
            var refund = await _context.Refunds.FindAsync(id);
            if (refund != null)
            {
                _context.Refunds.Remove(refund);
                await _context.SaveChangesAsync();
            }
        }
    }
}
