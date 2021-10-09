using Domain.Users;
using System;
using System.Windows.Forms;

namespace MontlyPayment
{
    public partial class frmEmployeePendingPayment : Form
    {
        private readonly IUsersBL _userBL;

        public string PaymentCode { get; set; }
        public int IdPayment { get; set; }
        public int IdUser { get; set; }

        public frmEmployeePendingPayment(IUsersBL userBL)
        {
            _userBL = userBL;

            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmployeePendingPayment_Load(object sender, EventArgs e)
        {
            PaymentCode = frmEmployeePayments.employeePayment.PayCode;
            IdPayment = frmEmployeePayments.employeePayment.PaymentID;
            IdUser = frmEmployeePayments.user.UserID;

            lblSalary.Text = frmEmployeePayments.employeePayment.TotalSalary.ToString();
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
            if (PaymentCode == txtEmployeeCode.Text)
            {
                _userBL.UpdatePendingPayment(IdUser, IdPayment);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Entered code is incorrect.");
            }
        }
    }
}
