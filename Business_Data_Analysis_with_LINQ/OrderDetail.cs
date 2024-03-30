using System.Globalization;

public class OrderDetail
{
    public string? orderid { get; set; }
    public string? productid { get; set; }
    public double unitprice { get; set; }
    public double quantity { get; set; }
    public double discount { get; set; }

    public static OrderDetail Csvm(string[] values)
    {
        return new OrderDetail
        {
            orderid = values[0],
            productid = values[1],
            unitprice = double.Parse(values[2], CultureInfo.InvariantCulture),
            quantity = double.Parse(values[3], CultureInfo.InvariantCulture),
            discount = double.Parse(values[4], CultureInfo.InvariantCulture)
        };
    }

    public override string ToString()
    {
        return orderid + " " + productid + " " + unitprice + " " + quantity + " " + discount;
    }
}
