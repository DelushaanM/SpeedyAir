using SpeedyAir.Model;

namespace SpeedyAir.Action;

public abstract class OrderScheduler
{
    public static List<ScheduledOrder> ScheduleOrders(List<Flight> flightSchedule, List<Order> orders)
    {
        if (flightSchedule == null)
        {
            throw new ArgumentNullException(nameof(flightSchedule));
        }

        if (orders == null)
        {
            throw new ArgumentNullException(nameof(orders));
        }

        if (!flightSchedule.Any())
        {
            throw new ArgumentException("Flight schedule cannot be empty", nameof(flightSchedule));
        }

        if (!orders.Any())
        {
            throw new ArgumentException("Orders cannot be empty", nameof(orders));
        }

        var scheduledOrders = new List<ScheduledOrder>();

        foreach (var order in orders)
        {
            if (order == null)
            {
                throw new ArgumentException("Order cannot be null");
            }

            foreach (var flight in flightSchedule)
            {
                if (flight == null)
                {
                    throw new ArgumentException("Flight cannot be null");
                }

                if (flight.Arrival == order.Destination && flight.Capacity > 0)
                {
                    scheduledOrders.Add(new ScheduledOrder
                    {
                        OrderId = order.OrderId,
                        FlightNumber = flight.FlightNumber,
                        Departure = flight.Departure,
                        Arrival = flight.Arrival,
                        Day = flight.Day
                    });

                    flight.Capacity--;
                    break;
                }
            }
        }

        return scheduledOrders;
    }
}