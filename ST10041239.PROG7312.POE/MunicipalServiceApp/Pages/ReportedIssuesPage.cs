using MunicipalServiceApp.Modals;
using MunicipalServiceApp.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportedIssuesPage : UserControl
    {
        public ReportedIssuesPage()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadReportedIssues();

        }

        private void LoadReportedIssues()
        {
            // Load reported issues from application state
            List<IssueReport> issues = StateManager.GetReportedIssues();

            // Bind the list of issues to the DataGridView
            dataGridViewIssues.DataSource = issues;
        }

        private void SetupDataGridView()
        {
            // Clear existing columns to avoid duplicates
            dataGridViewIssues.Columns.Clear();
        }

        private void InitializeComponent()
        {
            this.dataGridViewIssues = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAttachedFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReportedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIssues)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewIssues
            // 
            this.dataGridViewIssues.AllowUserToAddRows = false;
            this.dataGridViewIssues.AllowUserToDeleteRows = false;
            this.dataGridViewIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIssues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColumnId,
                this.ColumnLocation,
                this.ColumnCategory,
                this.ColumnDescription,
                this.ColumnAttachedFile,
                this.ColumnStatus,
                this.ColumnReportedDate});
            this.dataGridViewIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIssues.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewIssues.Name = "dataGridViewIssues";
            this.dataGridViewIssues.ReadOnly = true;
            this.dataGridViewIssues.Size = new System.Drawing.Size(800, 400);
            this.dataGridViewIssues.TabIndex = 0;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "ID";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Width = 50;
            // 
            // ColumnLocation
            // 
            this.ColumnLocation.HeaderText = "Location";
            this.ColumnLocation.Name = "ColumnLocation";
            this.ColumnLocation.ReadOnly = true;
            this.ColumnLocation.Width = 150;
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.HeaderText = "Category";
            this.ColumnCategory.Name = "ColumnCategory";
            this.ColumnCategory.ReadOnly = true;
            this.ColumnCategory.Width = 100;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            this.ColumnDescription.Width = 250;
            // 
            // ColumnAttachedFile
            // 
            this.ColumnAttachedFile.HeaderText = "Attached File";
            this.ColumnAttachedFile.Name = "ColumnAttachedFile";
            this.ColumnAttachedFile.ReadOnly = true;
            this.ColumnAttachedFile.Width = 250;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            this.ColumnStatus.Width = 100;
            // 
            // ColumnReportedDate
            // 
            this.ColumnReportedDate.HeaderText = "Reported Date";
            this.ColumnReportedDate.Name = "ColumnReportedDate";
            this.ColumnReportedDate.ReadOnly = true;
            this.ColumnReportedDate.Width = 120;
            // 
            // ReportedIssues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewIssues);
            this.Name = AppPages.ReportedIssues.ToString();
            this.Size = new System.Drawing.Size(800, 400);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIssues)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewIssues;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAttachedFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReportedDate;
    }
}
