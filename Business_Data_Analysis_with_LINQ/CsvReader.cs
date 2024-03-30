using System;
using System.Collections.Generic;
using System.IO;
public class CsvReader<T>
{
    public List<T> ReadCsv(string path, Func<string[], T> createObject)
    {
        List<T> dataList = new List<T>();
        try
        {
            using (var reader = new StreamReader(path))
            {
                reader.ReadLine(); //czytam linie z nazwami kolumn żeby ją skipnąć


                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    dataList.Add(createObject(values));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
        }
        return dataList;
    }
}
