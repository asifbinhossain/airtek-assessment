class JsonOrderProcessor(IJsonReader reader, IConsoleWriter writer)
{
    private readonly IJsonReader reader = reader;
    private readonly IConsoleWriter writer = writer;

    public void ProcessOrders(string filePath)
    {
        // Read orders from JSON file
        string jsonFilePath = reader.ReadJsonFile(filePath);
        var orderService = new OrderServiceJson(jsonFilePath);
        var orders = orderService.GetOrders();

        // Write Flights to console
        Console.WriteLine("\nUser story #1: Display Flights");
        var flightService = new FlightServiceStatic();
        var flights = flightService.GetFlights();
        writer.WriteFlights(flights);

        // Assign orders to flights
        Console.WriteLine("\nUser story #2: Assign Orders to Flights");
        var flightInventoryManager = new FlightInventoryManager(flights, orders);
        flightInventoryManager.AssignOrdersToFlights();

        // Print Orders for a flight
        Console.WriteLine("\nUser story #3: Get Orders in a Flight");
        flightInventoryManager.GetOrdersInAFlight(5);
        
    }
}