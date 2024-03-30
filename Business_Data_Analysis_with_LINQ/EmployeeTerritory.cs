public class EmployeeTerritory
{
    public string? employeeid { get; set; }
    public string? territoryid { get; set; }

    public static EmployeeTerritory Csvm(string[] values)
    {
        return new EmployeeTerritory
        {
            employeeid = values[0],
            territoryid = values[1]
        };
    }

    public override string ToString()
    {
        return employeeid + " " + territoryid;
    }
}