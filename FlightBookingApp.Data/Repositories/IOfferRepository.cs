﻿using FlightBookingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Data.Repositories
{
    public interface IOfferRepository
    {
        Task<IEnumerable<Offer>> GetOffersAsync();
        Task<Offer> GetOfferByIdAsync(int id);
        Task AddOfferAsync(Offer offer);
        Task UpdateOfferAsync(Offer offer);
        Task DeleteOfferAsync(int id);
    }
}
