using Newtonsoft.Json;
using SpeedyAirly.Model;

namespace AirSchedule.ScheduleFunction;

public abstract class Schedule
{
    public static List<Flight> LoadFlightSchedule()
        {
            // Define flight schedule
            var flights = new List<Flight>
            {
                new Flight { Number = 1, Departure = "YUL", Arrival = "YYZ", Day = 1 },
                new Flight { Number = 2, Departure = "YUL", Arrival = "YYC", Day = 1 },
                new Flight { Number = 3, Departure = "YUL", Arrival = "YVR", Day = 1 },
                new Flight { Number = 4, Departure = "YUL", Arrival = "YYZ", Day = 2 },
                new Flight { Number = 5, Departure = "YUL", Arrival = "YYC", Day = 2 },
                new Flight { Number = 6, Departure = "YUL", Arrival = "YVR", Day = 2 }
            };
            return flights;
        }

        public static void DisplayFlightSchedule(List<Flight> flights)
        {
            Console.WriteLine("Flight Schedule:");
            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight: {flight.Number}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
            }
        }

        public static List<Order> LoadOrders(string filePath)
        {
            try
            {
                // Read orders from JSON file
                var orders = new List<Order>();
                var json = File.ReadAllText(filePath);
                var orderDict = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
                foreach (var kvp in orderDict)
                {
                    orders.Add(new Order { OrderNumber = kvp.Key, Destination = kvp.Value.Destination });
                }
                return orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading orders: {ex.Message}");
                return new List<Order>(); // Return an empty list if an error occurs
            }
        }

        public static void GenerateFlightItineraries(List<Flight> flights, List<Order> orders)
        {
            try
            {
                Console.WriteLine("Generating Flight Itineraries:");

                foreach (var order in orders)
                {
                    bool scheduled = false;
                    foreach (var flight in flights)
                    {
                        if (order.Destination == flight.Arrival && order.Day == flight.Day)
                        {
                            Console.WriteLine($"order: {order.OrderNumber}, flightNumber: {flight.Number}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
                            scheduled = true;
                            break;
                        }
                    }
                    if (!scheduled)
                    {
                        Console.WriteLine($"order: {order.OrderNumber}, flightNumber: not scheduled");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while generating flight itineraries: {ex.Message}");
            }
        }

}