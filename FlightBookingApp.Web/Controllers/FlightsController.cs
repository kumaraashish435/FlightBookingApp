using FlightBookingApp.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingApp.Web.Controllers
{
    [Authorize]
    public class FlightsController : Controller
    {
        private readonly FlightService _flightService;

        public FlightsController(FlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<IActionResult> Index()
        {
            var flights = await _flightService.GetFlightsAsync();
            return View(flights);
        }
    }
}
