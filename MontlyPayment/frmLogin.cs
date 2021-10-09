using Domain.Users;
using Entities.Users;
using Entities.UserType;
using System;
using System.Windows.Forms;

namespace MontlyPayment
{
    public partial class frmLogin : Form
    {
        private readonly IUsersBL _userBL;

        public static User user;

        public frmLogin(IUsersBL userBL)
        {
            _userBL = userBL;

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = _userBL.Login(txtUsername.Text, txtPassword.Text, Convert.ToInt32(cboUserType.SelectedValue));

            if (user.UserID > 0)
            {
                if ((int)cboUserType.SelectedValue == (int)TypeUser.HHRR)
                {
                    frmPaymentList frmPaymentList = new frmPaymentList(_userBL);
                    frmPaymentList.Show();
                    Hide();
                }
                else if ((int)cboUserType.SelectedValue == (int)TypeUser.Employee)
                {
                    frmEmployeePayments frmEmployeePayments = new frmEmployeePayments(_userBL);
                    frmEmployeePayments.Show();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Username or Password incorrect");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            FillComboUserType();
        }

        private void FillComboUserType()
        {
            cboUserType.DataSource = _userBL.GetUsersType();
            cboUserType.ValueMember = "UserTypeID";
            cboUserType.DisplayMember = "Type";
        }
    }
}
