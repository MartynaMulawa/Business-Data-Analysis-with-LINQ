public class Region
{
    public string? regionid { get; set; }
    public string? regiondescription { get; set; }

    public static Region Csvm(string[] values)
    {
        return new Region
        {
            regionid = values[0],
            regiondescription = values[1]
        };
    }

    public override string ToString()
    {
        return regionid + " " + regiondescription;
    }
}