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
    public partial class frmReportRecipe : Form
    {
        private readonly IUsersBL _userBL;
        int idPayment;
        int idUser;

        public frmReportRecipe(IUsersBL userBL)
        {
            _userBL = userBL;

            InitializeComponent();
        }

        private void frmReportRecipe_Load(object sender, EventArgs e)
        {
            idPayment = frmEmployeePayments.employeePayment.PaymentID;
            idUser = frmEmployeePayments.user.UserID;

            ConfigureCrystalReports();
        }

        private void ConfigureCrystalReports()
        {
            ReportDocument reportDocument = new ReportDocument();

            var reportPath = Application.StartupPath + "\\Reports" + "\\rptEmployeeRecipe.rpt";
            reportDocument.Load(reportPath);
            reportDocument.SetDataSource(_userBL.RptGetRecipe(idUser, idPayment));
            crvReport.ReportSource = reportDocument;
        }
    }
}
