public class Territory
{
    public string? territoryid { get; set; }
    public string? territorydescription { get; set; }
    public string? regionid { get; set; }

    public static Territory Csvm(string[] values)
    {
        return new Territory
        {
            territoryid = values[0],
            territorydescription = values[1],
            regionid = values[2]
        };
    }

    public override string ToString()
    {
        return territoryid + " " + territorydescription + " " + regionid;
    }
}