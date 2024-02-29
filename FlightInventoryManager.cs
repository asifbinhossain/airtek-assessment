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

    public void AssignOrdersToFlightsByPriority() {
        var sameDayOrders = getSameDayOrders();
        var flights = getFlightsByDay(2);

        foreach (var order in sameDayOrders) {
            Flight? flight = GetFlightWithCapacity(flights);
            if (flight != null) {
                flight.BookFlight(order);
                Console.WriteLine($"Order: {order.Id}, flightNumber: {flight.Id}, departure: {flight.Origin.Code.IATA}, arrival: {flight.Destination.Code.IATA}, day: {flight.Day}");
            } else {
                Console.WriteLine($"Order: {order.Id}, flightNumber: not scheduled");
            }
        }
    }

    public void GetOrdersInAFlight(int flightId){
        var flight = this.flights.FirstOrDefault(flight => flight.Id == flightId);
        if (flight != null) {
            Console.WriteLine($"Flight: {flight.Id}, departure: {flight.Origin.Code.IATA}, arrival: {flight.Destination.Code.IATA}, day: {flight.Day}");
            Console.WriteLine("Orders:");
            foreach (var order in flight.Orders) {
                Console.WriteLine($"Order: {order.Id}");
            }
            return;
        }
        Console.WriteLine($"Flight: {flightId} not found");
    }


    private List<Flight> GetAvailableFlights(AirportCode destination) {
        var filteredFlights = this.flights.Where(
            flight => flight.Destination.Code.IATA == destination.IATA);
        return filteredFlights.ToList();
    }

    private Flight? GetFlightWithCapacity(List<Flight> flights) {
        return flights.FirstOrDefault(flight => flight.HasCapacity());
    }

    private List<Order> getSameDayOrders() {
        return this.orders.Where(order => order.Priority == OrderPriority.same_day).ToList();
    }

    private List<Flight> getFlightsByDay(int day) {
        return this.flights.Where(flight => flight.Day == day).ToList();
    }

}