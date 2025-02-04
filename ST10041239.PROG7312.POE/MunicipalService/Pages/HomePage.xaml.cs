﻿using MunicipalService.Pages;
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
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // Handles navigation to Reported Issues page
        private void ReportIssues_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReportIssuesPage());
        }
    }
}
