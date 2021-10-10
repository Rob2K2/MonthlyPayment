using Common.Helpers;
using Domain.Users;
using System;
using System.Windows.Forms;

namespace MontlyPayment
{
    public partial class frmEmployeePendingPayment : Form
    {
        private readonly IUsersBL _userBL;
        private readonly INumberLCD _numberLCD;

        public string PaymentCode { get; set; }
        public int IdPayment { get; set; }
        public int IdUser { get; set; }

        public frmEmployeePendingPayment(IUsersBL userBL, INumberLCD numberLCD)
        {
            _userBL = userBL;
            _numberLCD = numberLCD;

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
            var arrayCode = txtEmployeeCode.Text.Split('\n');
            var enteredCode = _numberLCD.LCDtoNumber(arrayCode);

            if (PaymentCode == enteredCode)
            {
                _userBL.UpdatePendingPayment(IdUser, IdPayment);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("The code you have entered is not correct.");
            }
        }
    }
}
