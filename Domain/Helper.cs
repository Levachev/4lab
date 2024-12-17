using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Everyone2Hackathon;

public class Helper
{
    private class CsvRecord
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

    public static List<Developer> ReadDevsFromCsv(string filename, Jobs job)
    {
        var result = new List<Developer>();

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = true,
        };

        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, config))
        {
            var records = csv.GetRecords<CsvRecord>();
            foreach (var record in records)
            {
                var dev = new Developer
                {
                    Id = record.Id,
                    Name = record.Name,
                    Job = job
                };
                result.Add(dev);
            }
        }

        return result;
    }

    public static double HarmonicMean(int[] numbers)
    {
        var sum = 0.0;

        foreach (var number in numbers)
        {
            sum += 1.0 / number;
        }

        return numbers.Length / sum;
    }
}
