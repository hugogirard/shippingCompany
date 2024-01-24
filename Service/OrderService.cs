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

    public async Task PostOrder(Order order)
    {
        var orderJson = JsonSerializer.Serialize(order);
        await _database.StringSetAsync(order.OrderDetail.ReqID, orderJson, TimeSpan.FromMinutes(10));
    }

    public async Task<IEnumerable<Order>> GetOrders()
    {
        var endpoints = _database.Multiplexer.GetEndPoints();
        var server = _database.Multiplexer.GetServer(endpoints[0]);
        var keys = server.Keys();
        var orders = new List<Order>();

        foreach (var key in keys)
        {
            var orderJson = await _database.StringGetAsync(key);
            var order = JsonSerializer.Deserialize<Order>(orderJson);
            orders.Add(order);
        }

        return orders;
    }

    public async Task PostOrder(Root root)
    {
        var orderJson = JsonSerializer.Serialize(root);
        await _database.StringSetAsync(root.Order.OrderDetail.ReqID, orderJson, TimeSpan.FromMinutes(10));
    }

    public async Task<IEnumerable<Root>> GetOrdersLivraisonRapide()
    {
        var endpoints = _database.Multiplexer.GetEndPoints();
        var server = _database.Multiplexer.GetServer(endpoints[0]);
        var keys = server.Keys();
        var orders = new List<Root>();

        foreach (var key in keys)
        {
            var orderJson = await _database.StringGetAsync(key);
            var order = JsonSerializer.Deserialize<Root>(orderJson);
            orders.Add(order);
        }

        return orders;
    }
}