using FlightBookingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Services.Interfaces
{
    public interface IRefundService
    {
        Task<IEnumerable<Refund>> GetRefundsAsync();
        Task<Refund> GetRefundByIdAsync(int id);
        Task AddRefundAsync(Refund refund);
        Task UpdateRefundAsync(Refund refund);
        Task DeleteRefundAsync(int id);
    }
}
