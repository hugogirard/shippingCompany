using System.Text.Json;
using ShippingCompany;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string redisCnxString = builder.Configuration["RedisCnxString"] ?? "localhost:6379";
var multiplexer = ConnectionMultiplexer.Connect(redisCnxString);
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
builder.Services.AddSingleton<IOrderService, OrderService>();

builder.Services.AddControllers(o => 
        {
            o.InputFormatters.Add(new XmlNoNameSpaceInputFormatter(o));
        })
        .AddXmlSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(o => 
{
    o.RoutePrefix = string.Empty;
    o.SwaggerEndpoint("/swagger/v1/swagger.json", "Shipping Company API");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
