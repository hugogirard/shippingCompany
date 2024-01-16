using System.Text.Json;
using StackExchange.Redis;

namespace ShippingCompany;

public class OrderService : IOrderService
{
    private readonly ILogger<OrderService> _logger;
    private IDatabase _database;
    private readonly IOrderService _orderService;

    public OrderService(ILogger<OrderService> logger,
                        IConnectionMultiplexer connectionMultiplexer)
    {
        _logger = logger;
        _database = connectionMultiplexer.GetDatabase();
    }

    public void PostOrder(Order order)
    {
        var orderJson = JsonSerializer.Serialize(order);
        _database.StringSet(order.OrderDetail.ReqID, orderJson, TimeSpan.FromMinutes(10));
    }

    public IEnumerable<Order> GetOrders()
    {
        var endpoints = _database.Multiplexer.GetEndPoints();
        var server = _database.Multiplexer.GetServer(endpoints[0]);
        var keys = server.Keys();
        var orders = new List<Order>();

        foreach (var key in keys)
        {
            var orderJson = _database.StringGet(key);
            var order = JsonSerializer.Deserialize<Order>(orderJson);
            orders.Add(order);
        }

        return orders;
    }
}