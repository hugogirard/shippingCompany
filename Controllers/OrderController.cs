using Microsoft.AspNetCore.Mvc;
using ShippingCompany;

public class OrderController : ControllerBase 
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    
    public IActionResult PostOrder([FromBody] Order order)
    {
        _orderService.PostOrder(order);
        return Ok();
    }

    [HttpGet]
    public IEnumerable<Order> GetOrders()
    {
        var orders =_orderService.GetOrders();

        return orders;
    }
}