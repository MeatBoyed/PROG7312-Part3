using MunicipalServiceApp.Services;
using MunicipalServiceApp.Modals;
using MunicipalServicesApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServiceApp.Services
{
    // PART - 2 Used to assign Pages their name/type
    public enum AppPages
    {
        Home,
        ReportIssues,
        ReportedIssues,
        RecommendedEvents,
        EventsAndAnnouncements,
        ServiceRequestStatus
    }

    internal class StateManager
    {
        public static readonly int clientWidth = 800;
        public static readonly int clientHeight = 850;
        public static readonly int pageWidth = 800;
        public static readonly int pageHeight = 800;

        //public static readonly int clientWidth = 400;
        //public static readonly int clientHeight = 450;
        //public static readonly int pageWidth = 400;
        //public static readonly int pageHeight = 400;

        // Stores the current Page
        public static UserControl currentPage;
        public static UserControl CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                // Notify any subscribers about the change
                OnCurrentPageChanged?.Invoke(currentPage);
            }
        }

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
        public static event Action<UserControl> OnCurrentPageChanged; // Event to notify changes

        // PART 2 - Allows all pages to access the Events and Announcements data store/Service
        public static EventsDataStoreService EventStoreServic = new EventsDataStoreService();
        public static RequestService RequestService = new RequestService();

        // Handles updating the Current Page, to the desired Page
        public static void NavigateToPage(UserControl page)
        {
            // If there is a currently visible page
            if (CurrentPage != null)
            {
                // Hide the current page and remove it from the panel
                CurrentPage.Visible = false;
            }

            // Assign the new page as the current page
            CurrentPage = page;
            CurrentPage.Dock = DockStyle.Fill;
            CurrentPage.Visible = true;
        }

        // Handles the navigation back in the window tree
        public static void NavigateBack()
        {
            if (currentPage.Name == AppPages.ReportIssues.ToString())
            {
                NavigateToPage(new HomePage());
            }else if (currentPage.Name == AppPages.ReportedIssues.ToString())
            {
                NavigateToPage(new ReportIssuesPage());
            }

            // PART 2 - Handles Events Announcments Navigation
            if (currentPage.Name == AppPages.EventsAndAnnouncements.ToString())
            {
                NavigateToPage(new HomePage());
            }else if (currentPage.Name == AppPages.RecommendedEvents.ToString())
            {
                NavigateToPage(new EventsAndAnnouncePage());
            }

            // PART 3 - Handles Service Request Status Navigation
            if (currentPage.Name == AppPages.ServiceRequestStatus.ToString())
            {
                NavigateToPage(new HomePage());
            }

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
            // Loading Issue Reports from Data Source
            List<IssueReport> response = CsvFileService.ReadFromCsv<IssueReport>(ResourcePathService.REPORTED_ISSUES_PATH);
            ReportPoints = response.Count();
            return response;
        }

        public static void CalculateReportPoints()
        {
            ReportPoints = GetReportedIssues().Count();
        }
    }
}
