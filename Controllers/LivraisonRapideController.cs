using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace ShippingCompany.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivraisonRapideController : ControllerBase
{
    private readonly IOrderService _orderService;

    public LivraisonRapideController(IOrderService orderService)
    {
        _orderService = orderService;
    }
  
    [HttpPost]    
    public async Task<IActionResult> PostOrder([FromBody] Root root)
    {
        await _orderService.PostOrder(root);
        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<Root>> GetOrders()
    {
        var orders = await _orderService.GetOrdersLivraisonRapide();

        return orders;
    }    
}
