using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace ShippingCompany.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GlobalEnvoieController : OrderController
{
    public GlobalEnvoieController(IOrderService orderService) : base(orderService)
    {
    }
   
    [HttpPost]
    [Consumes("application/xml")]
    override public IActionResult PostOrder([FromBody] Order order)
    {
        return base.PostOrder(order);
    }

    [HttpGet]
    [Produces("application/xml")]
    override public IEnumerable<Order> GetOrders()
    {
        var orders =_orderService.GetOrders();

        return orders;
    }

}
