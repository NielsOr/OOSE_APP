using CsvHelper;
using LOGIC.Interfaces.Files;
using LOGIC.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DAL.Files
{
    public class RubricsFileBuilder : IRubricsFileBuilder
    {
        public FileResultObject BuildFileCSV(IEnumerable<Rubric> records)
        {   
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                //csvWriter.Configuration.RegisterClassMap<MapObject>();
                csvWriter.WriteRecords(records);
            }
            return new FileResultObject
            {
                Content = memoryStream.ToArray(),
                FileName = "Module_evls.csv",
                ContentType = "text/csv"
            };
        }

        public FileResultObject BuildFileDOCX(IEnumerable<Rubric> records)
        {
            throw new System.NotImplementedException();
        }

        public FileResultObject BuildFilePDF(IEnumerable<Rubric> records)
        {
            throw new System.NotImplementedException();
        }
    }
}
