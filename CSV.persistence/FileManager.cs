using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CSV.Core.Model;
using System.Linq;

namespace CSV.persistence
{
    public class FileManager : IFileManager
    {


        public void Write<T>(string filePath, List<T> data)
        {

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }
        }
        public List<Log> Read(string filePath)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, configuration))
            {
                csv.Context.RegisterClassMap<LogMap>();
                var records = csv.GetRecords<Log>().ToList();
                return records;
            }

        }
    }
}

