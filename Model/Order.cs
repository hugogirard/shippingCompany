using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShippingCompany;

[XmlRoot(ElementName = "Order")]
public class Order
{
    [XmlElement(ElementName = "OrderDetail")]
    [JsonProperty("OrderDetail")]
    public OrderDetail OrderDetail { get; set; }

    [XmlElement(ElementName = "Item")]
    [JsonProperty("Items")]
    public List<Item> Items { get; set; }
}

public class OrderDetail
{
    [XmlElement(ElementName = "ReqID")]
    [JsonProperty("ReqID")]
    public string ReqID { get; set; }

    [XmlElement(ElementName = "OrderDate")]
    [JsonProperty("OrderDate")]
    public DateTime OrderDate { get; set; }

    [XmlElement(ElementName = "OrderedBy")]
    [JsonProperty("OrderedBy")]
    public string OrderedBy { get; set; }
}

public class Item
{
    [XmlElement(ElementName = "Description")]
    [JsonProperty("Description")]
    public string Description { get; set; }

    [XmlElement(ElementName = "Quantity")]
    [JsonProperty("Quantity")]
    public int Quantity { get; set; }
}
