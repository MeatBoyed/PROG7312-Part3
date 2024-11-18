using MunicipalServiceApp.Properties;
using MunicipalServiceApp.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            ResourcePathService.EnsureResourcesExist(); // Initialize csv files for data storing

            // Subscribing the MainWindow to the dynamic current page for displaying in Page Panle
            // This is Simulating the WPF Frame and Navigation features
            StateManager.OnCurrentPageChanged += UpdateCurrentPagePanel;
            StateManager.NavigateToPage(new HomePage());

            // Subscribing the MainWindow to the dynamic Report Point value for displaying
            StateManager.OnReportPointsChanged += UpdateReportPoints;
            StateManager.CalculateReportPoints();

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelReportPoints = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.CurrentPagePanel = new System.Windows.Forms.Panel();
            this.buttonReportIssues = new System.Windows.Forms.Button();
            this.buttonLocalEvents = new System.Windows.Forms.Button();
            this.buttonServiceStatus = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelReportPoints);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 62);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Municipal Services";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(468, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelReportPoints
            // 
            this.labelReportPoints.AutoSize = true;
            this.labelReportPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.labelReportPoints.ForeColor = System.Drawing.Color.White;
            this.labelReportPoints.Location = new System.Drawing.Point(432, 19);
            this.labelReportPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReportPoints.Name = "labelReportPoints";
            this.labelReportPoints.Size = new System.Drawing.Size(24, 26);
            this.labelReportPoints.TabIndex = 2;
            this.labelReportPoints.Text = "0";
            // 
            // buttonBack
            // 
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(311, 12);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(100, 37);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Go Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // CurrentPagePanel
            // 
            this.CurrentPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentPagePanel.Location = new System.Drawing.Point(0, 62);
            this.CurrentPagePanel.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentPagePanel.Name = "CurrentPagePanel";
            this.CurrentPagePanel.Size = new System.Drawing.Size(731, 584);
            this.CurrentPagePanel.TabIndex = 1;
            // 
            // buttonReportIssues
            // 
            this.buttonReportIssues.Location = new System.Drawing.Point(12, 60);
            this.buttonReportIssues.Name = "buttonReportIssues";
            this.buttonReportIssues.Size = new System.Drawing.Size(75, 23);
            this.buttonReportIssues.TabIndex = 0;
            this.buttonReportIssues.Text = "Report Issues";
            this.buttonReportIssues.Click += new System.EventHandler(this.ButtonReportIssues_Click);
            // 
            // buttonLocalEvents
            // 
            this.buttonLocalEvents.Enabled = false;
            this.buttonLocalEvents.Location = new System.Drawing.Point(12, 100);
            this.buttonLocalEvents.Name = "buttonLocalEvents";
            this.buttonLocalEvents.Size = new System.Drawing.Size(75, 23);
            this.buttonLocalEvents.TabIndex = 0;
            this.buttonLocalEvents.Text = "Local Events";
            // 
            // buttonServiceStatus
            // 
            this.buttonServiceStatus.Enabled = false;
            this.buttonServiceStatus.Location = new System.Drawing.Point(12, 140);
            this.buttonServiceStatus.Name = "buttonServiceStatus";
            this.buttonServiceStatus.Size = new System.Drawing.Size(75, 23);
            this.buttonServiceStatus.TabIndex = 0;
            this.buttonServiceStatus.Text = "Service Status";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 646);
            this.Controls.Add(this.CurrentPagePanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Municipal Services";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        // Handles User Navigation to go back
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            StateManager.NavigateBack();
        }

        private void ButtonReportIssues_Click(object sender, EventArgs args)
        {
            StateManager.NavigateToPage(new ReportIssuesPage());
        }


        // Handles updating the Current Page panel
        private void UpdateCurrentPagePanel(UserControl currentPage)
        {
            if (currentPage.Visible) CurrentPagePanel.Controls.Add(currentPage);
            else CurrentPagePanel.Controls.Remove(currentPage); 
        }

        // Handles updating the Report Point label
        private void UpdateReportPoints(int reportPoints)
        {
            labelReportPoints.Text = reportPoints.ToString();
        }

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label labelReportPoints;
        private Button buttonBack;
        private Panel CurrentPagePanel;
        private Button buttonReportIssues;
        private Button buttonLocalEvents;
        private Button buttonServiceStatus;
    }
}
