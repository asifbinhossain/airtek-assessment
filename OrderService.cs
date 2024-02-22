using System.Text.Json;

interface IOrderService
{
    public List<Order> GetOrders();
}


class OrderServiceJson : IOrderService
{
    private readonly string JsonDataSource;
    public OrderServiceJson(string jsonDataSource)
    {
        if (string.IsNullOrWhiteSpace(jsonDataSource))
        {
            throw new Exception("JSON Data source is empty or null");
        }
        this.JsonDataSource = jsonDataSource;
    }
    public List<Order> GetOrders()
    {
        try
        {
            // Deserialize JSON string into a dictionary
            // Format: { "order-001": { "destination": "YYZ" }, order-002: { "destination": "YVR" } }
            Dictionary<string, Dictionary<string, string>> ordersDictionary = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(this.JsonDataSource);
            List<Order> orders = new List<Order>();
            foreach (var orderEntry in ordersDictionary)
            {
                Airport destination = Airport.FromIataToAirport(orderEntry.Value["destination"]);
                Order newOrder = new Order(orderEntry.Key, destination);
                orders.Add(newOrder);
            }
            return orders;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error parsing JSON: {ex.Message}");
        }
    }
}