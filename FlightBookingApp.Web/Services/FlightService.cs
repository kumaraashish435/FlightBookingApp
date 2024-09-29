namespace FlightBookingApp.Web.Services
{
    public class FlightService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public FlightService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiUrl"];
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Flight>>($"{_apiUrl}/api/flights");
        }
    }
}
