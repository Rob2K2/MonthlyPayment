using Common.Helpers;
using Domain.Users;
using System;
using System.Windows.Forms;

namespace MontlyPayment
{
    public partial class frmPaymentList : Form
    {
        private readonly IUsersBL _userBL;
        private readonly INumberLCD _numberLCD;

        public static int idPayment;

        public frmPaymentList(IUsersBL userBL, INumberLCD numberLCD)
        {
            _userBL = userBL;
            _numberLCD = numberLCD;

            InitializeComponent();
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            monthlyPaymentTableAdapter.Fill(monthlyPaymentDataSet.MonthlyPayment);
            dtpToDate.Value = DateTime.Today;
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        }

        private void frmEmployeeList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNewPayment_Click(object sender, EventArgs e)
        {
            idPayment = 0;
            frmPayment frmEmployeeListDetails = new frmPayment(_userBL, _numberLCD);
            DialogResult res = frmEmployeeListDetails.ShowDialog();
            if (res == DialogResult.OK)
            {
                MessageBox.Show("Payment Saved Successfully");
                monthlyPaymentTableAdapter.Fill(monthlyPaymentDataSet.MonthlyPayment);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if ((dgvPayments.RowCount == 0))
            {
                MessageBox.Show("There are no rows to print.", "JALA");
                return;
            }
            idPayment = Convert.ToInt32(dgvPayments.CurrentRow.Cells["PaymentID"].Value);
            frmReport visualizador = new frmReport(_userBL);
            visualizador.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((dgvPayments.RowCount == 0))
            {
                MessageBox.Show("There are no rows to edit.", "JALA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            idPayment = Convert.ToInt32(dgvPayments.CurrentRow.Cells["PaymentID"].Value);
            frmPayment frmEmployeeListDetails = new frmPayment(_userBL, _numberLCD);
            DialogResult res = frmEmployeeListDetails.ShowDialog();
            if (res == DialogResult.OK)
            {
                MessageBox.Show("Edited successfully");
                dgvPayments.DataSource = _userBL.GetPayments();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bsPaymentList.MoveFirst();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bsPaymentList.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bsPaymentList.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bsPaymentList.MoveLast();
        }
    }
}
