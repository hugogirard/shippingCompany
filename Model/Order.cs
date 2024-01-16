namespace ShippingCompany;

public class Order
{
    public OrderDetail OrderDetail { get; set; }
    //public List<Item> Items { get; set; }
}

public class OrderDetail
{
    public string ReqID { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderedBy { get; set; }
}

public class Item
{
    public string Description { get; set; }
    public uint Quantity { get; set; }
}
