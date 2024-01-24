using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace ShippingCompany.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GlobalEnvoieController : ControllerBase
{
    private readonly IOrderService _orderService;

    public GlobalEnvoieController(IOrderService orderService)
    {
        _orderService = orderService;
    }
   
    [HttpPost]
    [Consumes("application/xml")]
    public async Task<IActionResult> PostOrder([FromBody] Order order)
    {
        await _orderService.PostOrder(order);
        return Ok();
    }

    [HttpGet]
    [Produces("application/xml")]
    public async Task<IEnumerable<Order>> GetOrders()
    {
        var orders = await _orderService.GetOrders();

        return orders;
    }

}
