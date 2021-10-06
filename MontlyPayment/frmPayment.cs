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
    public partial class frmPayment : Form
    {
        private readonly UsersBL userBL = new UsersBL();

        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            dgvEmployees.AutoGenerateColumns = false;
            var employees = userBL.GetEmployees();
            
            for (int i = 0; i < employees.Count; i++)
            {
                dgvEmployees.Rows.Add(employees[i].UserID, employees[i].Firstname, employees[i].Lastname, employees[i].Salary);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
