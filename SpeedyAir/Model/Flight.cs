namespace SpeedyAir.Model;

public class Flight
{
    public int FlightNumber { get; set; }
    public string? Departure { get; set; }
    public string? Arrival { get; set; }
    public int Day { get; set; }
    public int Capacity { get; set; }
}