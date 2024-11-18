using Microsoft.Win32;
using MunicipalService.Modals;
using MunicipalService.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// <summary>
    /// Interaction logic for ReportIssuesPage.xaml
    /// </summary>
    public partial class ReportIssuesPage : Page
    {
        // Progress Incre/Decre step values
        private int ProgressIncrement = 20;
        private int ProgressDecrement = 20;

        // Flags to track progress updates
        private bool isLocationProgressUpdated = false;
        private bool isDescriptionProgressUpdated = false;
        private bool isCategoryProgressUpdated = false;

        private string attachedFile;

        public ReportIssuesPage()
        {
            InitializeComponent();
            ProgressBar.Value = 0;
        }

        private void UpdateProgressBar(int change)
        {
            // Ensure the progress bar value stays within the range of 0 to 100
            ProgressBar.Value = Math.Max(0, Math.Min(100, ProgressBar.Value + change));
        }

        // Handle Updating Progress Bar on input for live feedback
        private void LocationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LocationTextBox.Text.Length >= 10 && !isLocationProgressUpdated)
            {
                UpdateProgressBar(ProgressIncrement);
                isLocationProgressUpdated = true; // Set flag to true after incrementing
            }
            else if (string.IsNullOrEmpty(LocationTextBox.Text))
            {
                UpdateProgressBar(-ProgressDecrement);
                isLocationProgressUpdated = false; // Reset flag when empty
            }
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem != null && !isCategoryProgressUpdated)
            {
                UpdateProgressBar(ProgressIncrement);
                isCategoryProgressUpdated = true;
            }
        }

        private void DescriptionRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string descriptionText = new TextRange(DescriptionRichTextBox.Document.ContentStart, DescriptionRichTextBox.Document.ContentEnd).Text;

            if (descriptionText.Length >= 10 && !isDescriptionProgressUpdated)
            {
                UpdateProgressBar(ProgressIncrement);
                isDescriptionProgressUpdated = true; // Set flag to true after incrementing
            }
            else if (string.IsNullOrEmpty(descriptionText))
            {
                UpdateProgressBar(-ProgressDecrement);
                isDescriptionProgressUpdated = false; // Reset flag when empty
            }
        }


        // Handles the File Input of any type of file implementation
        private void AttachMediaButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false, // Only allow a single file
                Title = "Select Files to Attach",
                Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Document Files (*.pdf;*.doc;*.docx)|*.pdf;*.doc;*.docx|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Store selected file path
                attachedFile = openFileDialog.FileName;
                AttachmentNameTextBlock.Text = attachedFile;
                MessageBox.Show("Files attached successfully!");
                UpdateProgressBar(ProgressIncrement);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect values from the UI
            string location = LocationTextBox.Text.Trim();
            string category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string description = new TextRange(DescriptionRichTextBox.Document.ContentStart, DescriptionRichTextBox.Document.ContentEnd).Text.Trim();
            DateTime reportedDate = DateTime.Now;

            // Validate input fields
            if (!ValidateInputs(location, category, description)) return; // Exit if validation fails

            // Create an IssueReport object
            IssueReport issue = new IssueReport()
            {
                Location = location,
                Category = category,
                Description = description,
                ReportedDate = reportedDate,
                AttachedFile = attachedFile,
                Status = "Unsettled"
            };

            // Offload Data to ApplicationStateManager
            try
            {
                int response = ApplicationStateManager.CreateReportIssue(issue);
                if (response == 500)
                {
                    MessageBox.Show($"An error occurred while submitting the report", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }else
                {
                    UpdateProgressBar(100);
                    MessageBox.Show(IssueReportToString(issue), "Issue Report Details");
                    ResetFields();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the report creation
                MessageBox.Show($"An error occurred while submitting the report: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViewIssues_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReportedIssuesPage());  
        }

        // Helper method for Printing out an Issue Report's values
        private string IssueReportToString(IssueReport reportedIssue)
        {
            return $"Issue Report ID: {reportedIssue.Id}\n" +
                       $"Location: {reportedIssue.Location}\n" +
                       $"Category: {reportedIssue.Category}\n" +
                       $"Description: {reportedIssue.Description}\n" +
                       $"Reported Date: {reportedIssue.ReportedDate.ToString("g")}\n" +
                       $"Status: {reportedIssue.Status}\n" +
                       $"Attached Files: {string.Join(", ", reportedIssue.AttachedFile)}";
        }

        // Handles Validation of Inputted Fields
        private bool ValidateInputs(string location, string category, string description)
        {
            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Location cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Setting a Character limit for the location
            if (location.Length < 10 || location.Length > 150)
            {
                MessageBox.Show("Location must be between 10 and 150 characters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Description cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (description.Length > 300)
            {
                MessageBox.Show("Description cannot exceed 300 characters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(attachedFile))
            {
                MessageBox.Show("Please attach one media file.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true; // All validations passed
        }

        // Handles Reseting form values and page state
        private void ResetFields()
        {
            // Clear the location textbox
            LocationTextBox.Text = string.Empty;
            isLocationProgressUpdated = false;

            // Reset the category selection to the first item or a default value
            CategoryComboBox.SelectedItem = null;
            isCategoryProgressUpdated = false;

            // Clear the description rich text box
            DescriptionRichTextBox.Document.Blocks.Clear();
            isDescriptionProgressUpdated = false;

            // Clear any attached files
            attachedFile = string.Empty;
            AttachmentNameTextBlock.Text = string.Empty;

            ProgressBar.Value = 0; // Reset progress bar to 0
        }
    }
}
