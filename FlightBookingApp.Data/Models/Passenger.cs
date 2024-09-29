using FlightBookingApp.Data.Models;
public class Passenger
{
    public int Id { get; set; }                   // Unique identifier
    public string Name { get; set; } = string.Empty; // Passenger name
    public int Age { get; set; }                  // Age
    public string Gender { get; set; } = string.Empty; // Gender
    public string Email { get; set; } = string.Empty; // Email ID
    public string PhoneNumber { get; set; } = string.Empty; // Phone number

    public int BookingId { get; set; }            // Foreign key for the related booking
    public Booking
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        g { get; set; } = new Booking(); // Navigation property to Booking
}
