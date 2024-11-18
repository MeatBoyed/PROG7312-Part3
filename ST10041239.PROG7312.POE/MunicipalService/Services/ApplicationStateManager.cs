using MunicipalService.Modals;
using MunicipalService.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MunicipalService.Services
{
    internal class ApplicationStateManager
    {
        // Stores the current Report Points
        public static int reportPoints;
        public static int ReportPoints
        {
            get => reportPoints;
            set
            {
                reportPoints = value;
                // Notify any subscribers about the change
                OnReportPointsChanged?.Invoke(reportPoints);
            }
        }

        public static event Action<int> OnReportPointsChanged; // Event to notify changes

        public static void CalculateReportPoints()
        {
            ReportPoints = GetReportedIssues().Count();
        }

        // Handles the Business Logic of Creating an Issue Report
        public static int CreateReportIssue(IssueReport reportedIssue)
        {
            reportedIssue.Id = reportPoints++; // increment Id
            bool response = CsvFileService.AppendIssueReportToCsv(ResourcePathService.REPORTED_ISSUES_PATH, reportedIssue); // Offload to Service
            if (!response) return 500; // Error status

            CalculateReportPoints(); // Update ReportPoints
            return 200; // success status
        }

        public static List<IssueReport> GetReportedIssues()
        {
            List<IssueReport> response = CsvFileService.ReadFromCsv<IssueReport>(ResourcePathService.REPORTED_ISSUES_PATH);
            ReportPoints = response.Count();
            return response;
        }
    }
}
