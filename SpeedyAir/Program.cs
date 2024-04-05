using Newtonsoft.Json;
using SpeedyAir.Action;
using SpeedyAir.Model;

public class Program
{
    public static void Main()
    {
        // Check if the file exists
        var filePath = "flightSchedule.json";
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        // Load flight schedule and orders
        var json = File.ReadAllText(filePath);
        var flightData = JsonConvert.DeserializeObject<FlightData>(json);

        if (flightData == null)
        {
            throw new ArgumentException("Failed to deserialize flight data");
        }

        if (flightData.FlightSchedule == null || flightData.Orders == null)
        {
            throw new ArgumentException("Flight schedule or orders data is missing in the JSON file");
        }

        // Schedule orders
        var scheduledOrders = OrderScheduler.ScheduleOrders(flightData.FlightSchedule, flightData.Orders);

        // Print scheduled orders
        foreach (var order in scheduledOrders)
        {
            Console.WriteLine($"Order: {order.OrderId}, FlightNumber: {order.FlightNumber}, Departure: {order.Departure}, Arrival: {order.Arrival}, Day: {order.Day}");
        }
    }
}



