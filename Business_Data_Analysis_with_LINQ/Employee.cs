public class Employee
{
    public string? employeeid { get; set; }
    public string? lastname { get; set; }
    public string? firstname { get; set; }
    public string? title { get; set; }
    public string? titleofcourtesy { get; set; }
    public string? birthdate { get; set; }
    public string? hiredate { get; set; }
    public string? address { get; set; }
    public string? city { get; set; }
    public string? region { get; set; }
    public string? postalcode { get; set; }
    public string? country { get; set; }
    public string? homephone { get; set; }
    public string? extension { get; set; }
    public string? photo { get; set; }
    public string? notes { get; set; }
    public string? reportsTo { get; set; }
    public string? photoPath { get; set; }

    public static Employee Csvm(string[] values)
    {
        return new Employee
        {
            employeeid = values[0],
            lastname = values[1],
            firstname = values[2],
            title = values[3],
            titleofcourtesy = values[4],
            birthdate = values[5],
            hiredate = values[6],
            address = values[7],
            city = values[8],
            region = values[9],
            postalcode = values[10],
            country = values[11],
            homephone = values[12],
            extension = values[13],
            photo = values[14],
            notes = values[15],
            reportsTo = values[16],
            photoPath = values[17]
        };
    }

    public override string ToString()
    {
        return $"{employeeid} {lastname} {firstname}";
    }
}
