using FlightBookingApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightBookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly HttpClient _httpClient;

        public FlightController(IFlightService flightService, HttpClient httpClient)
        {
            _flightService = flightService;
            _httpClient = httpClient;
        }

        // GET: api/flights/search?startLocation={}&destination={}&date={}&passengers={}&tripType={}
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Flight>>> SearchFlights(string startLocation, string destination, DateTime date, int passengers, string tripType)
        {
            var flights = await _flightService.SearchFlights(startLocation, destination, date, passengers, tripType);
            return Ok(flights);
        }

        // GET: api/flights/filter?stops={}&departureTime={}&arrivalTime={}
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Flight>>> FilterFlights(int stops, DateTime departureTime, DateTime arrivalTime)
        {
            var flights = await _flightService.FilterFlights(stops, departureTime, arrivalTime);
            return Ok(flights);
        }

        // GET: api/flights/recommendations?preference={preference}
        [HttpGet("recommendations")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetRecommendedFlights(string preference)
        {
            var flights = await _flightService.GetRecommendedFlights(preference);
            return Ok(flights);
        }

        // GET: api/flights/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlightById(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        // GET: api/flights/external
        [HttpGet("external")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetExternalFlights()
        {
            var response = await _httpClient.GetAsync("https://externalapi.com/flights");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error fetching data from external API");
            }

            var responseData = await response.Content.ReadAsStringAsync();
            var flights = JsonSerializer.Deserialize<IEnumerable<Flight>>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Ok(flights);
        }
    }
}