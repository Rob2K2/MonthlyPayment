using DataAccess.Users;
using Domain.Users;
using Entities.Users;
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
        private readonly IUsersBL _userBL;
        int idPayment;

        public frmPayment(IUsersBL userBL)
        {
            _userBL = userBL;

            InitializeComponent();
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            idPayment = frmPaymentList.idPayment;

            if (idPayment > 0)
            {
                var paymentList = _userBL.GetPaymentList(idPayment);
                dtpPaymentDate.Value = paymentList.PaymentDate;
                txtObservations.Text = paymentList.Observations;
                dgvEmployees.AutoGenerateColumns = false;

                var paymentDetail = _userBL.GetPaymentDetail(idPayment);
                for (int i = 0; i < paymentDetail.Count; i++)
                {
                    dgvEmployees.Rows.Add(paymentDetail[i].UserID, paymentDetail[i].Name, paymentDetail[i].Lastname, paymentDetail[i].Email, paymentDetail[i].BasicSalary,
                                      paymentDetail[i].Bonus, paymentDetail[i].Discounts, paymentDetail[i].TotalSalary, paymentDetail[i].IsPayed);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.RowCount == 0)
            {
                MessageBox.Show("List is Empty", "JALA");
            }
                        
            if (idPayment == 0)
            {
                idPayment = _userBL.InsertPaymentList(dtpPaymentDate.Value, txtObservations.Text);
            }
            else
            {
                _userBL.UpdatePaymentList(dtpPaymentDate.Value, txtObservations.Text, idPayment);
            }

            foreach (DataGridViewRow fila in dgvEmployees.Rows)
            {
                var paymentDetail = SetPaymentDetail(idPayment, Convert.ToInt32(fila.Cells["UserID"].Value), Convert.ToDecimal(fila.Cells["TotalSalary"].Value),
                                            Convert.ToBoolean(fila.Cells["Payed"].Value), fila.Cells["Name"].Value.ToString(), fila.Cells["Lastname"].Value.ToString(),
                                            fila.Cells["Email"].Value.ToString(), Convert.ToDecimal(fila.Cells["BasicSalary"].Value), Convert.ToDecimal(fila.Cells["Bonus"].Value),
                                            Convert.ToDecimal(fila.Cells["Discounts"].Value));
                _userBL.InsertPaymentDetail(paymentDetail);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private PaymentDetail SetPaymentDetail(int paymentID, int userID, decimal totalSalary, bool isPayed, string name, string lastname,
                                               string email, decimal basicSalary, decimal bonus, decimal discounts)
        {
            return new PaymentDetail
            {
                PaymentID = paymentID,
                UserID = userID,
                TotalSalary = totalSalary,
                IsPayed = isPayed,
                Name = name,
                Lastname = lastname,
                Email = email,
                BasicSalary = basicSalary,
                Bonus = bonus,
                Discounts = discounts
            };
        }

        private void btnLoadEmployees_Click(object sender, EventArgs e)
        {
            dgvEmployees.AutoGenerateColumns = false;
            var employees = _userBL.GetEmployees();

            for (int i = 0; i < employees.Count; i++)
            {
                dgvEmployees.Rows.Add(employees[i].UserID, employees[i].Firstname, employees[i].Lastname, employees[i].Email, employees[i].BasicSalary,
                                      employees[i].Bonus, employees[i].Discounts, employees[i].TotalSalary);
            }
        }
    }
}
