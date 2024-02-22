using System.Collections;

class Flight
{
    public int Id { get; set; }
    public Airport Origin { get; set; }
    public Airport Destination { get; set; }
    public int Day { get; set; }

    private int Capacity { get; set; }

    private List<Order> Orders { get; set; }

    public Flight(int id, Airport origin, Airport destination, int day)
    {
        Id = id;
        Origin = origin;
        Destination = destination;
        Day = day;
        Capacity = 20; // 20 orders per flight, Constant
        Orders = [];
    }

    public bool HasCapacity()
    {
        return Capacity > 0;
    }

    public void BookFlight(Order order)
    {
        if (HasCapacity())
        {
            this.Orders.Add(order);
            Capacity--;
            return;
        }
        Console.WriteLine($"Flight {Id} is fully booked, cannot book order {order.Id}");
        return;

    }

}

class Airport {
    public string City { get; set; }
    public AirportCode Code { get; set; }

    public Airport(string city, string code)
    {
        City = city;
        Code = new AirportCode(code);
    }

    static public Airport FromIataToAirport(string code)
    {
        AirportCode airportCode = new AirportCode(code);
        Dictionary<string, string> airportCodes = new Dictionary<string, string>
        {
            { "YYZ", "Toronto" },
            { "YVR", "Vancouver" },
            { "YUL", "Montreal" },
            { "YYC", "Calgary" },
            { "YYE", "Fort Nelson"}
        };
        if (!airportCodes.ContainsKey(airportCode.IATA))
        {
            Console.WriteLine($"IATA code {airportCode.IATA} not found");
            return new Airport("Unknown", airportCode.IATA);
        }
        return new Airport(airportCodes[airportCode.IATA], airportCode.IATA);

    }
}

class AirportCode {
    public string IATA { get; set; }

    public AirportCode(string iata)
    {
        if (iata.Length != 3)
        {
            throw new ArgumentException("IATA code must be 3 characters long");
        }
        IATA = iata;
    }
}

class Order{
    public string Id { get; set; }
    public Airport Destination { get; set; }
    public Order(string id, Airport destination)
    {
        Id = id;
        Destination = destination;
    }
}