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
   
}
