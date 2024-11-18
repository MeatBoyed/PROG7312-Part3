using MunicipalServiceApp.Modals;
using MunicipalServiceApp.Pages;
using MunicipalServiceApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{

    /// <summary>
    /// View the stored Events and Annoucnemnts
    /// </summary>
    public partial class ServiceRequestPage : UserControl
    {
        public ServiceRequestPage()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            // Populate data grid with Service Requests
            PopulateDataGrid(StateManager.RequestService.GetAllServiceRequests());    
            PopulateCategorySelector(); // Populate Selector with availble Categories
            PopulateStatusSelector(); // Populate Selector with availble Categories
        }

        // Feature 2 - 
        // Handles populating the Category Selector from the Avaible categories in the Data Store
        private void PopulateCategorySelector()
        {
            StateManager.RequestService.GetAllCategories().ToList().ForEach(category =>
            {
                comboBoxFilterCategory.Items.Add(category);
            });
            // adding "All" Option for viewing all categories (also handled automatically below)
            comboBoxFilterCategory.Items.Add(Category.All.ToString());
        }

        // Feature 3 - 
        // Handles populating the Status Category Selector from the Avaible categories in the Data Store
        private void PopulateStatusSelector()
        {
            StateManager.RequestService.GetAvailableStatuses().ToList().ForEach(status =>
            {
                comboBoxStatus.Items.Add(status);
            });
            // adding "All" Option for viewing all categories (also handled automatically below)
            comboBoxStatus.Items.Add(Category.All.ToString());
        }

        // Handles searching for Service Requests via Categories
        private void ButtonSearchCategoryAndDate_Click(object sender, EventArgs e)
        {
            // Get the selected category, and set it to All if none is selected
            string selectedCategory = (string)comboBoxStatus.SelectedItem;
            if (selectedCategory == null || selectedCategory == Category.All.ToString())
            {
              PopulateDataGrid(StateManager.RequestService.GetAllServiceRequests());    
                return;
            }

            // Execute the Data Service to search and get filtered results
            List<ServiceRequest> serviceRequests = StateManager.RequestService.FilterByStatus(selectedCategory);
            PopulateDataGrid(serviceRequests);
        }

        /// <summary>
        /// Feature 1 - Handles executing bussiness logic to Search Request by Id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearchID_Click(object sender, EventArgs e)
        {
            string inputedId = textBoxSearchID.Text;
            if (string.IsNullOrEmpty(inputedId))
            {
                PopulateDataGrid(StateManager.RequestService.GetAllServiceRequests());
                return;
            }
            int id = int.Parse(inputedId);

            ServiceRequest serviceRequest = StateManager.RequestService.SearchById(id);
            if (serviceRequest == null)
            {
                PopulateDataGrid(StateManager.RequestService.GetAllServiceRequests());
                return;
            }
            PopulateDataGrid(new List<ServiceRequest>() { serviceRequest });
        }

        /// <summary>
        /// Feature 2 - Handles executing business logic to Search/Filter Request by Category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearchCategory_Click(object sender, EventArgs e)
        {
            string category = (string)comboBoxFilterCategory.SelectedItem;
            PopulateDataGrid(StateManager.RequestService.FilterByCategory(category));
        }

        // Handles populating the Data Grid from the Data Store
        private void PopulateDataGrid(List<ServiceRequest> serviceRequests)
        {
              // Implemenet Tree algotihtms

            dataGridViewEvents.Rows.Clear();
            foreach (var serviceRequest in serviceRequests) // Adding each event and announcement to the Data Grid
            {
                int rowIndex = dataGridViewEvents.Rows.Add(
                     serviceRequest.Id,
                     serviceRequest.ReportedDate.ToShortDateString(),
                     serviceRequest.Description,
                     serviceRequest.Category.ToString(),
                     serviceRequest.Location,
                     serviceRequest.Status
                 );

                // Storing the event as a Tag in the data grid rows
                dataGridViewEvents.Rows[rowIndex].Tag = serviceRequest;
            }
        }

        private void InitializeComponent()
        {
            this.labelWelcome = new System.Windows.Forms.Label();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearchID = new System.Windows.Forms.TextBox();
            this.buttonSearchID = new System.Windows.Forms.Button();
            this.comboBoxFilterCategory = new System.Windows.Forms.ComboBox();
            this.buttonSearchCategory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelWelcome.Location = new System.Drawing.Point(9, 9);
            this.labelWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(284, 39);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Service Requests";
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.AllowUserToAddRows = false;
            this.dataGridViewEvents.AllowUserToDeleteRows = false;
            this.dataGridViewEvents.ColumnHeadersHeight = 29;
            this.dataGridViewEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            });
            this.dataGridViewEvents.Location = new System.Drawing.Point(16, 165);
            this.dataGridViewEvents.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.ReadOnly = true;
            this.dataGridViewEvents.RowHeadersWidth = 51;
            this.dataGridViewEvents.Size = new System.Drawing.Size(632, 381);
            this.dataGridViewEvents.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Category";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Location";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Status";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Location = new System.Drawing.Point(16, 132);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(367, 24);
            this.comboBoxStatus.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(392, 129);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(125, 28);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search by Status";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearchCategoryAndDate_Click);
            // 
            // textBoxSearchID
            // 
            this.textBoxSearchID.Location = new System.Drawing.Point(16, 59);
            this.textBoxSearchID.Name = "textBoxSearchID";
            this.textBoxSearchID.Size = new System.Drawing.Size(367, 22);
            this.textBoxSearchID.TabIndex = 8;
            // 
            // buttonSearchID
            // 
            this.buttonSearchID.Location = new System.Drawing.Point(392, 57);
            this.buttonSearchID.Name = "buttonSearchID";
            this.buttonSearchID.Size = new System.Drawing.Size(125, 23);
            this.buttonSearchID.TabIndex = 9;
            this.buttonSearchID.Text = "Search by ID";
            this.buttonSearchID.UseVisualStyleBackColor = true;
            this.buttonSearchID.Click += new System.EventHandler(this.buttonSearchID_Click);
            // 
            // comboBoxFilterCategory
            // 
            this.comboBoxFilterCategory.FormattingEnabled = true;
            this.comboBoxFilterCategory.Location = new System.Drawing.Point(16, 99);
            this.comboBoxFilterCategory.Name = "comboBoxFilterCategory";
            this.comboBoxFilterCategory.Size = new System.Drawing.Size(367, 24);
            this.comboBoxFilterCategory.TabIndex = 10;
            // 
            // buttonSearchCategory
            // 
            this.buttonSearchCategory.Location = new System.Drawing.Point(392, 99);
            this.buttonSearchCategory.Name = "buttonSearchCategory";
            this.buttonSearchCategory.Size = new System.Drawing.Size(125, 23);
            this.buttonSearchCategory.TabIndex = 11;
            this.buttonSearchCategory.Text = "Filter Category";
            this.buttonSearchCategory.UseVisualStyleBackColor = true;
            this.buttonSearchCategory.Click += new System.EventHandler(this.buttonSearchCategory_Click);
            // 
            // ServiceRequestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSearchCategory);
            this.Controls.Add(this.comboBoxFilterCategory);
            this.Controls.Add(this.buttonSearchID);
            this.Controls.Add(this.textBoxSearchID);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.dataGridViewEvents);
            this.Controls.Add(this.labelWelcome);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = AppPages.ServiceRequestStatus.ToString();
            this.Size = new System.Drawing.Size(658, 594);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.ComboBox comboBoxStatus; // Category selector
        private System.Windows.Forms.Button buttonSearch;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private TextBox textBoxSearchID;
        private Button buttonSearchID;
        private ComboBox comboBoxFilterCategory;
        private Button buttonSearchCategory;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

    }
}