using System;
using System.Collections.Generic;
using System.Linq;

class ProgramLinq
{
        static void Main(string[] args)
    {
   // 1. Wczytanie danych z plików CSV
        CsvReader<Employee> employeeReader = new CsvReader<Employee>();
        CsvReader<Region> regionReader = new CsvReader<Region>();
        CsvReader<Territory> territoryReader = new CsvReader<Territory>();
        CsvReader<EmployeeTerritory> employeeTerritoryReader = new CsvReader<EmployeeTerritory>();

        List<Employee> employees = employeeReader.ReadCsv("employees.csv", Employee.Csvm);
        List<Region> regions = regionReader.ReadCsv("regions.csv", Region.Csvm);
        List<Territory> territories = territoryReader.ReadCsv("territories.csv", Territory.Csvm);
        List<EmployeeTerritory> employeeTerritories = employeeTerritoryReader.ReadCsv("employee_territories.csv", EmployeeTerritory.Csvm);

        CsvReader<Order> orderReader = new CsvReader<Order>();
        CsvReader<OrderDetail> orderDetailReader = new CsvReader<OrderDetail>();

        List<Order> orders = orderReader.ReadCsv("orders.csv", Order.Csvm);
        List<OrderDetail> orderDetails = orderDetailReader.ReadCsv("orders_details.csv", OrderDetail.Csvm);


        // 1. Wybierz nazwiska wszystkich pracowników
        var employeeLastNames = from e in employees
                                select e.lastname;

        Console.WriteLine("Nazwiska wszystkich pracowników:");
        foreach (var lastName in employeeLastNames)
        {
            Console.WriteLine(lastName);
        }
        Console.WriteLine();

        // 2. Wypisz nazwiska pracowników oraz dla każdego z nich nazwę regionu i terytorium, gdzie pracuje
        var employeeDetails = from e in employees
                              join et in employeeTerritories on e.employeeid equals et.employeeid
                              join t in territories on et.territoryid equals t.territoryid
                              join r in regions on t.regionid equals r.regionid into regionGroup
                              from region in regionGroup
                              select new
                              {
                                  EmployeeName = e.lastname,
                                  RegionName = region != null ? region.regiondescription : null,
                                  TerritoryDescription = t.territorydescription
                              };

        Console.WriteLine("Nazwiska pracowników oraz nazwy regionów i terytoriów:");
        foreach (var detail in employeeDetails)
        {
            Console.WriteLine($"Pracownik: {detail.EmployeeName}, Region: {detail.RegionName ?? "Brak"}, Terytorium: {detail.TerritoryDescription}");
        }
        Console.WriteLine();

        // 3. Wypisz nazwy regionów oraz nazwiska pracowników, którzy pracują w tych regionach
        var employeesByRegion = from r in regions
                                join t in territories on r.regionid equals t.regionid into territoryGroup
                                from territory in territoryGroup
                                join et in employeeTerritories on territory.territoryid equals et.territoryid into employeeTerritoryGroup
                                from employeeTerritory in employeeTerritoryGroup
                                join e in employees on employeeTerritory.employeeid equals e.employeeid
                                group e.lastname by r.regiondescription into g
                                select new
                                {
                                    RegionName = g.Key,
                                    Employees = g.Distinct()
                                };

        Console.WriteLine("Nazwy regionów oraz nazwiska pracowników:");
        foreach (var item in employeesByRegion)
        {
            Console.WriteLine($"Region: {item.RegionName}");
            foreach (var employeeName in item.Employees)
            {
                Console.WriteLine($" - {employeeName}");
            }
        }
        Console.WriteLine();

        // 4. Wypisz nazwy regionów oraz liczbę pracowników w tych regionach
        var employeesCountByRegion = from r in regions
                                     join t in territories on r.regionid equals t.regionid into territoryGroup
                                     from territory in territoryGroup
                                     join et in employeeTerritories on territory.territoryid equals et.territoryid into employeeTerritoryGroup
                                     from employeeTerritory in employeeTerritoryGroup
                                     join e in employees on employeeTerritory.employeeid equals e.employeeid
                                     group e by r.regiondescription into g
                                     select new
                                     {
                                         RegionName = g.Key,
                                         EmployeeCount = g.Distinct().Count()
                                     };

        Console.WriteLine("Nazwy regionów oraz liczba pracowników:");
        foreach (var item in employeesCountByRegion)
        {
            Console.WriteLine($"Region: {item.RegionName}, Liczba pracowników: {item.EmployeeCount}");
        }
        Console.WriteLine();

        // 5. Wypisz statystyki zamówień dla każdego pracownika
        var employeeOrderStats = from o in orders
                                 join od in orderDetails on o.orderid equals od.orderid into orderDetailGroup
                                 from orderDetail in orderDetailGroup
                                 group orderDetail by o.employeeid into g
                                 orderby g.Key
                                 select new
                                 {
                                     EmployeeId = g.Key,
                                     OrderCount = g.Count(),
                                     AverageOrderValue = g.Any() ? g.Average(od => od.unitprice * od.quantity * (1 - od.discount)) : 0,
                                     MaxOrderValue = g.Any() ? g.Max(od => od.unitprice * od.quantity * (1 - od.discount)) : 0
                                 };

        Console.WriteLine("Statystyki zamówień dla każdego pracownika:");
        foreach (var stat in employeeOrderStats)
        {
            var employeeLastName = (from e in employees
                                    where e.employeeid == stat.EmployeeId
                                    select e.lastname).FirstOrDefault();

            Console.WriteLine($"Pracownik {stat.EmployeeId} ({employeeLastName}):");
            Console.WriteLine($"- Liczba zamówień: {stat.OrderCount}");
            Console.WriteLine($"- Średnia wartość zamówienia: {stat.AverageOrderValue:C}");
            Console.WriteLine($"- Maksymalna wartość zamówienia: {stat.MaxOrderValue:C}");
            Console.WriteLine();
        }
    }
}
