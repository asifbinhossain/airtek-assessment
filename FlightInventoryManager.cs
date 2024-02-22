class FlightInventoryManager(List<Flight> flights, List<Order> orders)
{
    private readonly List<Flight> flights = flights;
    private readonly List<Order> orders = orders;

    public void AssignOrdersToFlights() {
        foreach (var order in this.orders) {
            List<Flight> availableFlights = GetAvailableFlights(order.Destination.Code);
            Flight? flight = GetFlightWithCapacity(availableFlights);
            if (flight != null) {
                flight.BookFlight(order);
                Console.WriteLine($"Order: {order.Id}, flightNumber: {flight.Id}, departure: {flight.Origin.Code.IATA}, arrival: {flight.Destination.Code.IATA}, day: {flight.Day}");
            } else {

                Console.WriteLine($"Order: {order.Id}, flightNumber: not scheduled");
            }
        }
    }


    private List<Flight> GetAvailableFlights(AirportCode destination) {
        var filteredFlights = this.flights.Where(
            flight => flight.Destination.Code.IATA == destination.IATA);
        return filteredFlights.ToList();
    }

    private Flight? GetFlightWithCapacity(List<Flight> flights) {
        return flights.FirstOrDefault(flight => flight.HasCapacity());
    }

}