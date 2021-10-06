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
    public partial class frmPaymentList : Form
    {
        private readonly UsersBL userBL = new UsersBL();

        public frmPaymentList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            dtpToDate.Value = DateTime.Today;
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.DataSource = userBL.GetPayments();
        }

        private void frmEmployeeList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewPayment_Click(object sender, EventArgs e)
        {
            frmPayment frmEmployeeListDetails = new frmPayment();
            DialogResult res = frmEmployeeListDetails.ShowDialog();
            if (res == DialogResult.OK)
            {
                MessageBox.Show("Guardado correctamente");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
