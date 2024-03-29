﻿using Common.Helpers;
using Domain.Settings;
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
        private readonly INumberLCD _numberLCD;
        private readonly ISettingsBL _settingsBL;

        public static User user;

        public frmLogin(IUsersBL userBL, INumberLCD numberLCD, ISettingsBL settingsBL)
        {
            _userBL = userBL;
            _numberLCD = numberLCD;
            _settingsBL = settingsBL;

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                user = _userBL.Login(txtUsername.Text, txtPassword.Text, Convert.ToInt32(cboUserType.SelectedValue));

                if (user.UserID > 0)
                {
                    if ((int)cboUserType.SelectedValue == (int)TypeUser.HHRR)
                    {
                        frmPaymentList frmPaymentList = new frmPaymentList(_userBL, _numberLCD);
                        frmPaymentList.Show();
                        frmPaymentList.FormClosed += Logout;
                        Hide();
                    }
                    else if ((int)cboUserType.SelectedValue == (int)TypeUser.Employee)
                    {
                        frmEmployeePayments frmEmployeePayments = new frmEmployeePayments(_userBL, _numberLCD, _settingsBL);
                        frmEmployeePayments.Show();
                        frmEmployeePayments.FormClosed += Logout;
                        Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

            Show();
            txtUsername.Focus();
        }
    }
}
