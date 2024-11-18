using MunicipalServiceApp.Services;
using MunicipalServiceApp;
using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill; 
        }

        private void InitializeComponent()
        {
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonReportIssues = new System.Windows.Forms.Button();
            this.buttonLocalEvents = new System.Windows.Forms.Button();
            this.buttonServiceStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(5, 15);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(281, 74);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to \nMunicipal Services";
            // 
            // buttonReportIssues
            // 
            this.buttonReportIssues.Location = new System.Drawing.Point(100, 100);
            this.buttonReportIssues.Name = "buttonReportIssues";
            this.buttonReportIssues.Size = new System.Drawing.Size(200, 40);
            this.buttonReportIssues.TabIndex = 1;
            this.buttonReportIssues.Text = "Report Issues";
            this.buttonReportIssues.UseVisualStyleBackColor = true;
            this.buttonReportIssues.Click += new System.EventHandler(this.ButtonReportIssues_Click);
            // 
            // buttonLocalEvents
            // 
            this.buttonLocalEvents.Location = new System.Drawing.Point(100, 150);
            this.buttonLocalEvents.Name = "buttonLocalEvents";
            this.buttonLocalEvents.Size = new System.Drawing.Size(200, 40);
            this.buttonLocalEvents.TabIndex = 2;
            this.buttonLocalEvents.Text = "Local Events and Announcements";
            this.buttonLocalEvents.UseVisualStyleBackColor = true;
            this.buttonLocalEvents.Click += new System.EventHandler(this.buttonLocalEvents_Click);
            // 
            // buttonServiceStatus
            // 
            this.buttonServiceStatus.Enabled = true;
            this.buttonServiceStatus.Location = new System.Drawing.Point(100, 200);
            this.buttonServiceStatus.Name = "buttonServiceStatus";
            this.buttonServiceStatus.Size = new System.Drawing.Size(200, 40);
            this.buttonServiceStatus.TabIndex = 3;
            this.buttonServiceStatus.Text = "Service Request Status";
            this.buttonServiceStatus.UseVisualStyleBackColor = true;
            this.buttonServiceStatus.Click += new System.EventHandler(this.buttonServiceStatus_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonServiceStatus);
            this.Controls.Add(this.buttonLocalEvents);
            this.Controls.Add(this.buttonReportIssues);
            this.Controls.Add(this.labelWelcome);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(400, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ButtonReportIssues_Click(object sender, EventArgs e)
        {
            StateManager.NavigateToPage(new ReportIssuesPage());
        }

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonReportIssues;
        private System.Windows.Forms.Button buttonLocalEvents;
        private System.Windows.Forms.Button buttonServiceStatus;

        private void buttonLocalEvents_Click(object sender, EventArgs e)
        {
            StateManager.NavigateToPage(new EventsAndAnnouncePage());
        }

        private void buttonServiceStatus_Click(object sender, EventArgs e)
        {
            StateManager.NavigateToPage(new ServiceRequestPage());
        }
    }
}