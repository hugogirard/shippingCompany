using Microsoft.AspNetCore.Mvc;
using ShippingCompany;

public class OrderController : ControllerBase 
{
    protected readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    
    public virtual IActionResult PostOrder([FromBody] Order order)
    {
        _orderService.PostOrder(order);
        return Ok();
    }

    [HttpGet]
    public virtual IEnumerable<Order> GetOrders()
    {
        var orders =_orderService.GetOrders();

        return orders;
    }
}