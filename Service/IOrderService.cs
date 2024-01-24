namespace ShippingCompany;

public interface IOrderService 
{
    Task PostOrder(Order order);

    Task<IEnumerable<Order>> GetOrders();

    Task PostOrder(Root root);

    Task<IEnumerable<Root>> GetOrdersLivraisonRapide();    
}