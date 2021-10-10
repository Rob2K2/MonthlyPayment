using Common.Helpers;
using Domain.Users;
using Entities.Users;
using System;
using System.Windows.Forms;

namespace MontlyPayment
{
    public partial class frmEmployeePayments : Form
    {
        private readonly IUsersBL _userBL;
        private readonly INumberLCD _numberLCD;

        public static User user;
        public static PaymentDetail employeePayment = new PaymentDetail();

        public frmEmployeePayments(IUsersBL userBL, INumberLCD numberLCD)
        {
            _userBL = userBL;
            _numberLCD = numberLCD;

            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmployeePayments_Load(object sender, EventArgs e)
        {
            user = frmLogin.user;
            dtpToDate.Value = DateTime.Today;
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            lblName.Text = user.Firstname;
            lblLastname.Text = user.Lastname;
            var employeePayments = _userBL.GetEmployeePayments(user.UserID);
            dgvEmployeePayments.AutoGenerateColumns = false;
            dgvEmployeePayments.DataSource = employeePayments;
        }

        private void frmEmployeePayments_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnEarn_Click(object sender, EventArgs e)
        {
            if ((dgvEmployeePayments.RowCount == 0))
            {
                MessageBox.Show("There are no payments to claim.", "JALA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var payed = Convert.ToBoolean(dgvEmployeePayments.CurrentRow.Cells["IsPayed"].Value);
            if (!payed)
            {
                employeePayment.PayCode = dgvEmployeePayments.CurrentRow.Cells["PayCode"].Value.ToString();
                employeePayment.PaymentID = Convert.ToInt32(dgvEmployeePayments.CurrentRow.Cells["PaymentID"].Value);
                employeePayment.TotalSalary = Convert.ToDecimal(dgvEmployeePayments.CurrentRow.Cells["TotalSalary"].Value);
                frmEmployeePendingPayment frmEmployeePendingPayment = new frmEmployeePendingPayment(_userBL, _numberLCD);
                DialogResult res = frmEmployeePendingPayment.ShowDialog();
                if (res == DialogResult.OK)
                {
                    MessageBox.Show("Get paid successfully");
                    dgvEmployeePayments.DataSource = _userBL.GetEmployeePayments(user.UserID);
                }
            }
            else
            {
                MessageBox.Show("Payment was already claimed.", "JALA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
