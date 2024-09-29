using FlightBookingApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly ILogger<FlightsController> _logger;

        public FlightsController(IFlightService flightService, ILogger<FlightsController> logger)
        {
            _flightService = flightService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            _logger.LogInformation("Getting all flights");
            var flights = await _flightService.GetFlightsAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            _logger.LogInformation("Getting flight with ID {FlightId}", id);
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null)
            {
                _logger.LogWarning("Flight with ID {FlightId} not found", id);
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpPost]
        public async Task<ActionResult> AddFlight(Flight flight)
        {
            _logger.LogInformation("Adding a new flight");
            await _flightService.AddFlightAsync(flight);
            return CreatedAtAction(nameof(GetFlight), new { id = flight.Id }, flight);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFlight(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                _logger.LogWarning("Flight ID mismatch: {FlightId} != {Flight.Id}", id, flight.Id);
                return BadRequest();
            }
            _logger.LogInformation("Updating flight with ID {FlightId}", id);
            await _flightService.UpdateFlightAsync(flight);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFlight(int id)
        {
            _logger.LogInformation("Deleting flight with ID {FlightId}", id);
            await _flightService.DeleteFlightAsync(id);
            return NoContent();
        }
    }
}