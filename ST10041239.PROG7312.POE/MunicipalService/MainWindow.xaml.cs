using MunicipalService.Modals;
using MunicipalService.Pages;
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

namespace MunicipalService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            ResourcePathService.EnsureResourcesExist(); // Initialize csv files for data storing

            // Subscribing the MainWindow to the dynamic Report Point value for displaying
            ApplicationStateManager.OnReportPointsChanged += UpdateReportPoints;
            ApplicationStateManager.CalculateReportPoints(); // Sets the report point value

            MainFrame.Navigate(new HomePage()); // Navigate to the initial page
        }

        // Handles updating the Report Points value
        private void UpdateReportPoints(int newReportPoints)
        {
            ReportPointsTB.Text = newReportPoints.ToString();
        }

        private void NavigateBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack(); // Ensures it doesn't crash going too far back
        }
    }
}
