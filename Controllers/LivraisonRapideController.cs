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
}