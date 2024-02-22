interface IConsoleWriter
{
    void WriteOrders(List<Order> orders);
    void WriteFlights(List<Flight> flights);
}


class ProgramConsoleWriter : IConsoleWriter
{
    public void WriteOrders(List<Order> orders)
    {
        foreach (var order in orders)
        {
            Console.WriteLine($"Order ID: {order.Id}, Destination: {order.Destination.City} ({order.Destination.Code.IATA})");
        }
    }

    public void WriteFlights(List<Flight> flights)
    {
        foreach (var flight in flights)
        {
            Console.WriteLine($"Flight: {flight.Id}, departure: {flight.Origin.Code.IATA}, arrival: {flight.Destination.Code.IATA}, day: {flight.Day}");
        }
    }
}

