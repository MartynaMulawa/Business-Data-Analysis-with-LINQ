public class Order
{
    public string? orderid { get; set; }
    public string? customerid { get; set; }
    public string? employeeid { get; set; }
    public string? orderdate { get; set; }
    public string? requireddate { get; set; }
    public string? shippeddate { get; set; }
    public string? shipvia { get; set; }
    public string? freight { get; set; }
    public string? shipname { get; set; }
    public string? shipaddress { get; set; }
    public string? shipcity { get; set; }
    public string? shipregion { get; set; }
    public string? shippostalcode { get; set; }
    public string? shipcountry { get; set; }

    public static Order Csvm(string[] values)
    {
        return new Order
        {
            orderid = values[0],
            customerid = values[1],
            employeeid = values[2],
            orderdate = values[3],
            requireddate = values[4],
            shippeddate = values[5],
            shipvia = values[6],
            freight = values[7],
            shipname = values[8],
            shipaddress = values[9],
            shipcity = values[10],
            shipregion = values[11],
            shippostalcode = values[12],
            shipcountry = values[13]
        };
    }

    public override string ToString()
    {
        return orderid + " " + customerid + " " + employeeid + " " + orderdate + " " + requireddate + " " + shippeddate + " " + shipvia + " " + freight + " " + shipname + " " + shipaddress + " " + shipcity + " " + shipregion + " " + shippostalcode + " " + shipcountry;
    }
}