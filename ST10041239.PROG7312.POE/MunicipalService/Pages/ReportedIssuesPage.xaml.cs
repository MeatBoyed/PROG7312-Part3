using MunicipalService.Modals;
using MunicipalService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MunicipalService.Pages
{
    public partial class ReportedIssuesPage : Page
    {
        public ReportedIssuesPage()
        {
            InitializeComponent();
            LoadReportedIssues();
        }

        private void LoadReportedIssues()
        {
            // Load reported issues from application state
            List<IssueReport> reportedIssues = ApplicationStateManager.GetReportedIssues();

            // Bind the list of issues to the ListView
            IssuesListView.ItemsSource = reportedIssues;
        }
    }
}
