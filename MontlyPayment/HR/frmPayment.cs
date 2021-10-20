using Common.Helpers;
using Domain.Users;
using Entities.Users;
using System;
using System.IO;
using System.Windows.Forms;

namespace MontlyPayment
{
    public partial class frmPayment : Form
    {
        private readonly IUsersBL _userBL;
        private readonly INumberLCD _numberLCD;
        int idPayment;

        public frmPayment(IUsersBL userBL, INumberLCD numberLCD)
        {
            _userBL = userBL;
            _numberLCD = numberLCD;

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
                    dgvEmployees.Rows.Add(paymentDetail[i].UserID, paymentDetail[i].Name, paymentDetail[i].Lastname, paymentDetail[i].Email, 
                                          paymentDetail[i].BasicSalary, paymentDetail[i].Bonus, paymentDetail[i].Discounts, paymentDetail[i].TotalSalary,
                                          paymentDetail[i].IsPayed);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            if (dgvEmployees.RowCount == 0)
            {
                MessageBox.Show("List is Empty", "JALA");

                return;
            }

            if (idPayment == 0)
            {
                idPayment = _userBL.InsertPaymentList(dtpPaymentDate.Value, txtObservations.Text);
            }
            else
            {
                _userBL.UpdatePaymentList(dtpPaymentDate.Value, txtObservations.Text, idPayment);
            }

            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                var selected = Convert.ToBoolean(row.Cells["Payed"].Value);
                if (selected)
                {
                    var payCode = rnd.Next(100000000, 999999999);
                    var arrayCode = _numberLCD.NumberToLCD(payCode).Split('\n');

                    var paymentDetail = SetPaymentDetail(idPayment, row.Cells["Name"].Value.ToString(), Convert.ToInt32(row.Cells["UserID"].Value),
                                                         Convert.ToDecimal(row.Cells["TotalSalary"].Value), false, payCode.ToString(), arrayCode,
                                                         row.Cells["Currency"].Value.ToString(), Convert.ToDecimal(row.Cells["CurrencyValue"].Value));
                    _userBL.InsertPaymentDetail(paymentDetail);

                    // Create a file to write to.
                    var filePath = Application.StartupPath + "\\Codes\\code" + paymentDetail.Name + dtpPaymentDate.Value.Day +
                                   dtpPaymentDate.Value.Month + dtpPaymentDate.Value.Year + ".txt";
                    File.WriteAllText(filePath, _numberLCD.NumberToLCD(payCode));
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private PaymentDetail SetPaymentDetail(int paymentID, string name, int userID, decimal totalSalary, bool isPayed, string payCode,
                                               string[] arrayCode, string currency, decimal currencyValue)
        {
            return new PaymentDetail
            {
                PaymentID = paymentID,
                Name = name,
                UserID = userID,
                TotalSalary = totalSalary,
                IsPayed = isPayed,
                PayCode = payCode,
                TopCode = arrayCode[0],
                MidCode = arrayCode[1],
                BotCode = arrayCode[2],
                Currency = currency,
                CurrencyValue = currencyValue
            };
        }

        private void btnLoadEmployees_Click(object sender, EventArgs e)
        {
            dgvEmployees.AutoGenerateColumns = false;
            var employees = _userBL.GetEmployees();

            for (int i = 0; i < employees.Count; i++)
            {
                dgvEmployees.Rows.Add(employees[i].UserID, employees[i].Firstname, employees[i].Lastname, employees[i].Email, employees[i].BasicSalary,
                                      employees[i].Bonus, employees[i].Discounts, employees[i].TotalSalary, employees[i].Currency, employees[i].CurrencyValue);
            }
        }
    }
}
