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
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await _offerRepository.GetOffersAsync();
        }

        public async Task<Offer> GetOfferByIdAsync(int id)
        {
            return await _offerRepository.GetOfferByIdAsync(id);
        }

        public async Task AddOfferAsync(Offer offer)
        {
            await _offerRepository.AddOfferAsync(offer);
        }

        public async Task UpdateOfferAsync(Offer offer)
        {
            await _offerRepository.UpdateOfferAsync(offer);
        }

        public async Task DeleteOfferAsync(int id)
        {
            await _offerRepository.DeleteOfferAsync(id);
        }
    }
}
