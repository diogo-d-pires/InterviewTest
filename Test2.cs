public class OrderProcessor
{
    private readonly List<Order> _orders = new List<Order>();
    private readonly object _lock = new object();

    public void ProcessOrders()
    {
        // Simulating a time-consuming operation
        foreach (var order in _orders)
        {
            ProcessOrder(order);
        }
    }

    public async Task AddOrderAsync(Order order)
    {
        // Blocking async call with .Result which can lead to deadlocks
        var result = await SaveOrderAsync(order).Result;
        
        lock (_lock)
        {
            _orders.Add(order); // Potential race condition
        }
    }

    private async Task<string> SaveOrderAsync(Order order)
    {
        // Simulating async database call
        await Task.Delay(1000);
        Console.WriteLine("Order saved: " + order.OrderId);
        return "Success";
    }
}

public class Order
{
    public int OrderId { get; set; }
    public string Product { get; set; }
}
