using CsvHelper;
using MunicipalServiceApp.Modals;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServiceApp.Services
{
    /// <summary>
    /// Handles domain specific implementation for Reading and Writing to CSV file
    /// </summary>
    internal class CsvFileService
    {
        // Ensure the CSV file exists and initialize it with headers if necessary
        public static void EnsureCsvFileExists<T>(string filePath, string headerLine)
        {
            if (!File.Exists(filePath))
            {
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(headerLine); // Write the header line
                }
            }
        }

        // Reads contents from CSV file
        public static List<T> ReadFromCsv<T>(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return new List<T>(csv.GetRecords<T>());
            }
        }

        // Appends a single issue report to the CSV file
        public static bool AppendIssueReportToCsv(string filePath, IssueReport issue)
        {
            try
            {
                using (var writer = new StreamWriter(filePath, true)) // 'true' to append
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecord(issue);
                    writer.WriteLine(); // Write a new line after the record
                }
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
