namespace ShippingCompany;

public interface IOrderService 
{
    void PostOrder(Order order);

    IEnumerable<Order> GetOrders();
}