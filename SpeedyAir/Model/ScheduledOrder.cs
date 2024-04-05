namespace SpeedyAir.Model;

public class ScheduledOrder
{
    public string? OrderId { get; set; }
    public int FlightNumber { get; set; }
    public string? Departure { get; set; }
    public string? Arrival { get; set; }
    public int Day { get; set; }
}