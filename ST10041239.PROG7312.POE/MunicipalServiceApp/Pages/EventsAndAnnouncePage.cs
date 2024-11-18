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
    public partial class EventsAndAnnouncePage : UserControl
    {
        public EventsAndAnnouncePage()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            // Populate data grid with Events and Announcements
            PopulateDataGrid(StateManager.EventStoreServic.GetAllEventAnnouncements().Values.ToList());    
            PopulateCategorySelector(); // Populate Selector with availble Categories
        }

        // Handles populating the Category Selector from the Avaible categories in the Data Store
        private void PopulateCategorySelector()
        {
            StateManager.EventStoreServic.GetUniqueCategories().ToList().ForEach(category =>
            {
                comboBoxCategory.Items.Add(category);
            });
            // adding "All" Option for viewing all categories (also handled automatically below)
            comboBoxCategory.Items.Add(Category.All);
        }

        // Handles searching for Events and Announcements via Categories and Date Range
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            // Get the selected category, and set it to All if none is selected
            Category? selectedCategory = (Category?)comboBoxCategory.SelectedItem;
            if (selectedCategory == null) selectedCategory = Category.All;

            var startDate = dateTimePickerStart.Value.Date;
            var endDate = dateTimePickerEnd.Value.Date;

            // Execute the Data Service to search and get filtered results
            List<EventAnnouncement> filteredEvents = StateManager.EventStoreServic.SearchByCategoryAndDate((Category)selectedCategory, startDate, endDate);
            PopulateDataGrid(filteredEvents);
        }

        // Handles tracking user interaction on clicking on an Event
        private void DataGridViewEvents_CellClick(object sender, DataGridViewCellEventArgs eventArgs)
        {
            if (eventArgs.RowIndex >= 0) 
            {
                // Retrieve the EventAnnouncement object from the Tag property
                EventAnnouncement selectedEvent = dataGridViewEvents.Rows[eventArgs.RowIndex].Tag as EventAnnouncement;

                if (selectedEvent != null)
                {
                    StateManager.EventStoreServic.TrackUserInteraction(selectedEvent); // Track interaction in Data Store
                }
            }
        }

        // Handles Navigation to Recommenedd Page
        private void buttonViewRecommendations_Click(object sender, EventArgs e)
        {
            StateManager.NavigateToPage(new RecommendedPage());
        }

        // Handles populating the Data Grid from the Data Store
        private void PopulateDataGrid(List<EventAnnouncement> eventAnnouncements)
        {
            dataGridViewEvents.Rows.Clear();
            foreach (var eventAnnouncement in eventAnnouncements) // Adding each event and announcement to the Data Grid
            {
                int rowIndex = dataGridViewEvents.Rows.Add(
                     eventAnnouncement.Title,
                     eventAnnouncement.Date.ToShortDateString(),
                     eventAnnouncement.Time.HasValue ? eventAnnouncement.Time.Value.ToString(@"hh\:mm") : "N/A", // Ensures time is formatted correctly
                     eventAnnouncement.Description,
                     eventAnnouncement.Category.ToString(),
                     eventAnnouncement.Location ?? "N/A", // Ensures N/A is displayed if location is null
                     eventAnnouncement.ContactInfo ?? "N/A"
                 );

                // Storing the event as a Tag in the data grid rows
                dataGridViewEvents.Rows[rowIndex].Tag = eventAnnouncement;
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
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonViewRecommendations = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelWelcome.Location = new System.Drawing.Point(7, 18);
            this.labelWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(442, 39);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Events and Announcements";
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
            this.dataGridViewTextBoxColumn7});
            this.dataGridViewEvents.Location = new System.Drawing.Point(16, 147);
            this.dataGridViewEvents.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.ReadOnly = true;
            this.dataGridViewEvents.RowHeadersWidth = 51;
            this.dataGridViewEvents.Size = new System.Drawing.Size(501, 290);
            this.dataGridViewEvents.TabIndex = 7;
            this.dataGridViewEvents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewEvents_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Title";
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
            this.dataGridViewTextBoxColumn3.HeaderText = "Time";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Description";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Category";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Location";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Contact Info";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Location = new System.Drawing.Point(16, 115);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(367, 24);
            this.comboBoxCategory.TabIndex = 4;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(16, 81);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(236, 22);
            this.dateTimePickerStart.TabIndex = 5;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(292, 81);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(225, 22);
            this.dateTimePickerEnd.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(392, 111);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(125, 28);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // buttonViewRecommendations
            // 
            this.buttonViewRecommendations.Location = new System.Drawing.Point(392, 445);
            this.buttonViewRecommendations.Margin = new System.Windows.Forms.Padding(4);
            this.buttonViewRecommendations.Name = "buttonViewRecommendations";
            this.buttonViewRecommendations.Size = new System.Drawing.Size(125, 28);
            this.buttonViewRecommendations.TabIndex = 1;
            this.buttonViewRecommendations.Text = "Recommended For You";
            this.buttonViewRecommendations.UseVisualStyleBackColor = true;
            this.buttonViewRecommendations.Click += new System.EventHandler(this.buttonViewRecommendations_Click);
            // 
            // EventsAndAnnouncePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonViewRecommendations);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dataGridViewEvents);
            this.Controls.Add(this.labelWelcome);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = AppPages.EventsAndAnnouncements.ToString();
            this.Size = new System.Drawing.Size(533, 492);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.ComboBox comboBoxCategory; // Category selector
        private DateTimePicker dateTimePickerStart;       // Start date picker
        private DateTimePicker dateTimePickerEnd;         // End date picker
        private System.Windows.Forms.Button buttonViewRecommendations;
        private System.Windows.Forms.Button buttonSearch;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;


    }
}