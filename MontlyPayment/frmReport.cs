using CrystalDecisions.CrystalReports.Engine;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MontlyPayment
{
    public partial class frmReport : Form
    {
        private readonly IUsersBL _userBL;
        int idPayment;

        public frmReport(IUsersBL userBL)
        {
            _userBL = userBL;

            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            idPayment = frmPaymentList.idPayment;
            ConfigureCrystalReports();
        }

        private void ConfigureCrystalReports()
        {
            string reportPath;
            ReportDocument reportDocument = new ReportDocument();
            
            DataSet ds = new DataSet();
            //ds.Merge(_userBL.RptGetPaymentList(idPayment));

            reportPath = Application.StartupPath + "\\Reports" + "\\rptPayment.rpt";
            reportDocument.Load(reportPath);
            reportDocument.SetDataSource(_userBL.RptGetPaymentList(idPayment));
            crvReport.ReportSource = reportDocument;
        }
    }
}

