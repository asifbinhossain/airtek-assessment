interface IFlightService
{
    List<Flight> GetFlights();
}


class FlightServiceStatic : IFlightService
{
    public List<Flight> GetFlights()
    {
        List<Flight> flights =
        [
            // Flights on DAY 1
            new Flight(1, Airport.FromIataToAirport("YUL"), Airport.FromIataToAirport("YYZ"), 1),
            new Flight(2, Airport.FromIataToAirport("YUL"), Airport.FromIataToAirport("YYC"), 1),
            new Flight(3, Airport.FromIataToAirport("YUL"), Airport.FromIataToAirport("YVR"), 1),
            
            // Flights on DAY 2
            new Flight(4, Airport.FromIataToAirport("YUL"), Airport.FromIataToAirport("YYZ"), 2),
            new Flight(5, Airport.FromIataToAirport("YUL"), Airport.FromIataToAirport("YYC"), 2),
            new Flight(6, Airport.FromIataToAirport("YUL"), Airport.FromIataToAirport("YVR"), 2),
        ];
        return flights;
    }
}