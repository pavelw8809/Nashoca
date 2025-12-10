using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Tests.Helpers
{
    internal static class FileHandler
    {
        public static IEnumerable<T> GetCsvData<T>(string filePath, string delimeter = ",")
        {
            Console.WriteLine($"File path: {filePath}");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimeter,
                HasHeaderRecord = true,
                IgnoreBlankLines = true,
                MissingFieldFound = null,
                HeaderValidated = null
            };

            if (File.Exists(filePath))
            {
                using var csvReader = new StreamReader(filePath);
                using var csv = new CsvReader(csvReader, config);
                csv.Context.TypeConverterCache.AddConverter<bool>(new BooleanConverter());

                return csv.GetRecords<T>().ToList();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
