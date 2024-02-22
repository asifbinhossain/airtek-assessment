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
        var flightService = new FlightServiceStatic();
        var flights = flightService.GetFlights();
        writer.WriteFlights(flights);

        // Assign orders to flights
        var flightInventoryManager = new FlightInventoryManager(flights, orders);
        flightInventoryManager.AssignOrdersToFlights();
        
    }
}