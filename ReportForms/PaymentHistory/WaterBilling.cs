﻿using Echo.Data.Repository;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tenancy_Management_Information_Systems.ReportForms.PaymentHistory
{
    public partial class WaterBilling : Form
    {
        public WaterBilling(string _unitNo)
        {
            InitializeComponent();

            LoadReport(_unitNo);
        }

        private void LoadReport(string _unitNo)
        {
            using (var db = new EchoEntities())
            {
                waterBillingPaymentHistoryBindingSource.DataSource =
                    db.MonthlyAssocPaymentHistory(_unitNo);

                ReportParameter[] rParams = new ReportParameter[]
                {
                    new ReportParameter("UnitNo", _unitNo)
                };

                reportViewer.LocalReport.SetParameters(rParams);

                reportViewer.RefreshReport();
            }
        }

        private void WaterBilling_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }
}
