﻿using FlightBookingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Services.Interfaces
{
    public interface ITravelInsuranceService
    {
        Task<IEnumerable<TravelInsurance>> GetTravelInsurancesAsync();
        Task<TravelInsurance> GetTravelInsuranceByIdAsync(int id);
        Task AddTravelInsuranceAsync(TravelInsurance travelInsurance);
        Task UpdateTravelInsuranceAsync(TravelInsurance travelInsurance);
        Task DeleteTravelInsuranceAsync(int id);
    }
}
