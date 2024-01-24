using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShippingCompany;

public class Root 
{
    public OrderJSON Order { get; set; }
}


public class OrderJSON
{    
    public OrderDetailJSON OrderDetail { get; set; }

    public List<ItemJSON> Item { get; set; }
}

public class OrderDetailJSON
{

    public string ReqID { get; set; }


    public string OrderDate { get; set; }


    public string OrderedBy { get; set; }
}

public class ItemJSON
{

    public string Description { get; set; }


    public int Quantity { get; set; }
}
