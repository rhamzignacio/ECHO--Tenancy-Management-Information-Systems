﻿namespace Tenancy_Management_Information_Systems.ReportForms.PaymentHistory
{
    partial class MonthlyAssociationDue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.echoDataSet = new Tenancy_Management_Information_Systems.EchoDataSet();
            this.monthlyAssocPaymentHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monthlyAssocPaymentHistoryTableAdapter = new Tenancy_Management_Information_Systems.EchoDataSetTableAdapters.MonthlyAssocPaymentHistoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.echoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyAssocPaymentHistoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MonthlyAssoc";
            reportDataSource1.Value = this.monthlyAssocPaymentHistoryBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Tenancy_Management_Information_Systems.Reports.MonthlyAssocPaymentHistory.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(756, 401);
            this.reportViewer.TabIndex = 0;
            // 
            // echoDataSet
            // 
            this.echoDataSet.DataSetName = "EchoDataSet";
            this.echoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // monthlyAssocPaymentHistoryBindingSource
            // 
            this.monthlyAssocPaymentHistoryBindingSource.DataMember = "MonthlyAssocPaymentHistory";
            this.monthlyAssocPaymentHistoryBindingSource.DataSource = this.echoDataSet;
            // 
            // monthlyAssocPaymentHistoryTableAdapter
            // 
            this.monthlyAssocPaymentHistoryTableAdapter.ClearBeforeFill = true;
            // 
            // MonthlyAssociationDue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 401);
            this.Controls.Add(this.reportViewer);
            this.Name = "MonthlyAssociationDue";
            this.Text = "Monthly Association Due";
            this.Load += new System.EventHandler(this.MonthlyAssociationDue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.echoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyAssocPaymentHistoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource monthlyAssocPaymentHistoryBindingSource;
        private EchoDataSet echoDataSet;
        private EchoDataSetTableAdapters.MonthlyAssocPaymentHistoryTableAdapter monthlyAssocPaymentHistoryTableAdapter;
    }
}