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
    public class RefundService : IRefundService
    {
        private readonly IRefundRepository _refundRepository;

        public RefundService(IRefundRepository refundRepository)
        {
            _refundRepository = refundRepository;
        }

        public async Task<IEnumerable<Refund>> GetRefundsAsync()
        {
            return await _refundRepository.GetRefundsAsync();
        }

        public async Task<Refund> GetRefundByIdAsync(int id)
        {
            return await _refundRepository.GetRefundByIdAsync(id);
        }

        public async Task AddRefundAsync(Refund refund)
        {
            await _refundRepository.AddRefundAsync(refund);
        }

        public async Task UpdateRefundAsync(Refund refund)
        {
            await _refundRepository.UpdateRefundAsync(refund);
        }

        public async Task DeleteRefundAsync(int id)
        {
            await _refundRepository.DeleteRefundAsync(id);
        }
    }
}
