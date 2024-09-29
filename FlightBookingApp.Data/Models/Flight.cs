public class Flight
{
    public int Id { get; set; }                   // Unique identifier
    public string FlightNumber { get; set; } = string.Empty;       // Flight number (e.g., AI-202)
    public string Airline { get; set; } = string.Empty;            // Airline name (e.g., Air India)
    public string StartLocation { get; set; } = string.Empty;      // Start location (e.g., New York)
    public string Destination { get; set; } = string.Empty;        // Destination (e.g., London)
    public DateTime DepartureTime { get; set; }    // Departure time
    public DateTime ArrivalTime { get; set; }      // Arrival time
    public int NumberOfStops { get; set; }         // Number of stops (e.g., 1 stop, non-stop)
    public decimal Fare { get; set; }              // Ticket fare
    public string TripType { get; set; } = string.Empty;           // Round-trip, One-way, Multi-city
}