using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace ShippingCompany.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivraisonRapideController : OrderController
{
    public LivraisonRapideController(IOrderService orderService) : base(orderService)
    {
        
    }

    /*
    <?xml version="1.0" encoding="UTF-8"?>
    <Order>
        <OrderDetail>
            <ReqID>12345</ReqID>
            <OrderDate>2022-01-01T00:00:00</OrderDate>
            <OrderedBy>John Doe</OrderedBy>
        </OrderDetail>
    </Order>
    */
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
