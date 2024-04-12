using AirSchedule.ScheduleFunction;

using System;

namespace SpeedyAirly
{ 
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var flights = Schedule.LoadFlightSchedule();
                var ordersFilePath = "orders.json"; // Change the file path accordingly
                var orders = Schedule.LoadOrders(ordersFilePath);

                Schedule.DisplayFlightSchedule(flights);
                Console.WriteLine();
                Schedule.GenerateFlightItineraries(flights, orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
