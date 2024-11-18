using MunicipalServiceApp.Modals;
using MunicipalServiceApp.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesPage : UserControl
    {
        // Progress Incre/Decre step values
        private int ProgressIncrement = 20;
        private int ProgressDecrement = 20;

        // Flags to track progress updates
        private bool isLocationProgressUpdated = false;
        private bool isDescriptionProgressUpdated = false;
        private bool isCategoryProgressUpdated = false;
        private Button button1;
        private string attachedFile;

        public ReportIssuesPage()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void InitializeComponent()
        {
            this.labelLocation = new System.Windows.Forms.Label();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.buttonAttachMedia = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelMediaAttachment = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(27, 25);
            this.labelLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(61, 16);
            this.labelLocation.TabIndex = 0;
            this.labelLocation.Text = "Location:";
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(175, 25);
            this.textBoxLocation.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(318, 22);
            this.textBoxLocation.TabIndex = 1;
            this.textBoxLocation.TextChanged += new System.EventHandler(this.textBoxLocation_TextChanged);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(27, 74);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(65, 16);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Category:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "hello",
            "you",
            "sxy"});
            this.comboBoxCategory.Location = new System.Drawing.Point(175, 74);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(318, 24);
            this.comboBoxCategory.TabIndex = 3;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(27, 123);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(78, 16);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Description:";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(175, 123);
            this.richTextBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(318, 122);
            this.richTextBoxDescription.TabIndex = 5;
            this.richTextBoxDescription.Text = "";
            this.richTextBoxDescription.TextChanged += new System.EventHandler(this.richTextBoxDescription_TextChanged);
            // 
            // buttonAttachMedia
            // 
            this.buttonAttachMedia.Location = new System.Drawing.Point(360, 273);
            this.buttonAttachMedia.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAttachMedia.Name = "buttonAttachMedia";
            this.buttonAttachMedia.Size = new System.Drawing.Size(133, 37);
            this.buttonAttachMedia.TabIndex = 6;
            this.buttonAttachMedia.Text = "Attach Media";
            this.buttonAttachMedia.UseVisualStyleBackColor = true;
            this.buttonAttachMedia.Click += new System.EventHandler(this.buttonAttachMedia_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(360, 377);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(133, 37);
            this.buttonSubmit.TabIndex = 7;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // labelMediaAttachment
            // 
            this.labelMediaAttachment.AutoSize = true;
            this.labelMediaAttachment.Location = new System.Drawing.Point(27, 283);
            this.labelMediaAttachment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMediaAttachment.Name = "labelMediaAttachment";
            this.labelMediaAttachment.Size = new System.Drawing.Size(140, 16);
            this.labelMediaAttachment.TabIndex = 8;
            this.labelMediaAttachment.Text = "Media Attached: None";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(30, 333);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(463, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 377);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "ViewReports";
            this.button1.Size = new System.Drawing.Size(133, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "View Reports";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReportIssuesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelMediaAttachment);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonAttachMedia);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.labelLocation);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = AppPages.ReportIssues.ToString();
            this.Size = new System.Drawing.Size(516, 436);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Button buttonAttachMedia;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelMediaAttachment;

        private void UpdateProgressBar(int change)
        {
            // Ensure the progress bar value stays within the range of 0 to 100
            progressBar1.Value = Math.Max(0, Math.Min(100, progressBar1.Value + change));
        }

        // On Change Event methods - Handle Updating Progress Bar on input for live feedback
        private void textBoxLocation_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLocation.Text.Length >= 10 && !isLocationProgressUpdated)
            {
                UpdateProgressBar(ProgressIncrement);
                isLocationProgressUpdated = true; // Set flag to true after incrementing
            }
            else if (string.IsNullOrEmpty(textBoxLocation.Text))
            {
                UpdateProgressBar(-ProgressDecrement);
                isLocationProgressUpdated = false; // Reset flag when empty
            }
        }


        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem != null && !isCategoryProgressUpdated)
            {
                UpdateProgressBar(ProgressIncrement);
                isCategoryProgressUpdated = true;
            }
        }

        private void richTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            string descriptionText = richTextBoxDescription.Text;

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

        private void buttonAttachMedia_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false, // Only allow a single file
                Title = "Select Files to Attach",
                Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Document Files (*.pdf;*.doc;*.docx)|*.pdf;*.doc;*.docx|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Store selected file path
                attachedFile = openFileDialog.FileName;
                labelMediaAttachment.Text = attachedFile;
                MessageBox.Show("Files attached successfully!");
                UpdateProgressBar(ProgressIncrement);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Collect values from the UI
            string location = textBoxLocation.Text.Trim();
            string category = (comboBoxCategory.SelectedItem)?.ToString();
            string description = richTextBoxDescription.Text;
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
                int response = StateManager.CreateReportIssue(issue);
                if (response == 500)
                {
                    MessageBox.Show($"An error occurred while submitting the report", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    UpdateProgressBar(100);
                    MessageBox.Show(IssueReportToString(issue), "Issue Report Details");
                    ResetFields();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the report creation
                MessageBox.Show($"An error occurred while submitting the report: {ex.Message}", "Error", MessageBoxButtons.OK);
            }

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
                MessageBox.Show("Location cannot be empty.", "Validation Error", MessageBoxButtons.OK);
                return false;
            }

            // Setting a Character limit for the location
            if (location.Length < 10 || location.Length > 150)
            {
                MessageBox.Show("Location must be between 10 and 150 characters.", "Validation Error", MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Description cannot be empty.", "Validation Error", MessageBoxButtons.OK);
                return false;
            }

            if (description.Length > 300)
            {
                MessageBox.Show("Description cannot exceed 300 characters.", "Validation Error", MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(attachedFile))
            {
                MessageBox.Show("Please attach one media file.", "Validation Error", MessageBoxButtons.OK);
                return false;
            }

            return true; // All validations passed
        }

        private void ResetFields()
        {
            // Clear the location textbox
            textBoxLocation.Text = string.Empty;
            isLocationProgressUpdated = false;

            // Reset the category selection to the first item or a default value
            comboBoxCategory.SelectedItem = null;
            isCategoryProgressUpdated = false;

            // Clear the description rich text box
            richTextBoxDescription.Text = string.Empty;
            isDescriptionProgressUpdated = false;

            // Clear any attached files
            attachedFile = string.Empty;
            labelMediaAttachment.Text = string.Empty;

            progressBar1.Value = 0; // Reset progress bar to 0
        }

        // Handles Navigating to view Reported Issues
        private void button1_Click(object sender, EventArgs e)
        {
            StateManager.NavigateToPage(new ReportedIssuesPage());
        }
    }
}