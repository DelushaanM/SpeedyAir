namespace SpeedyAirly.Model;

public class Order
{
    public string OrderNumber { get; set; }
    public string Destination { get; set; }
    public int FlightNumber { get; set; }
    public string Departure { get; set; }
    public string Arrival { get; set; }
    public int Day { get; set; }
}