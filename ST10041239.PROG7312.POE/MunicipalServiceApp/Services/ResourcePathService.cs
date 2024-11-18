using MunicipalServiceApp.Modals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServiceApp.Services
{
    internal class ResourcePathService
    {
        // Setting data store values (constants)
        private static readonly string ROOT_DIRECTORY = "Data";
        public static readonly string REPORTED_ISSUES_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ROOT_DIRECTORY, "reported_issues.csv");

        public static void EnsureResourcesExist()
        {
            EnsureRootDirectoryExists(); // Ensure Root Directory exists
            InitializeCsvFiles(); // Ensure CsvFile(s) exists
        }

        private static void EnsureRootDirectoryExists()
        {
            var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ROOT_DIRECTORY);
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }
        }


        private static void InitializeCsvFiles()
        {
            // Ensure the issue report CSV file exists and initialize with headers
            CsvFileService.EnsureCsvFileExists<IssueReport>(REPORTED_ISSUES_PATH, "Id,Location,Category,Description,AttachedFile,ReportedDate,Status");
        }
    }
}
