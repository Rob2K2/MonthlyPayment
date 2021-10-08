﻿using DataAccess.Users;
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
    public partial class frmLogin : Form
    {
        private readonly IUsersBL _userBL;

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
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                if (_userBL.Login(txtUsername.Text, txtPassword.Text, Convert.ToInt32(cboUserType.SelectedValue)))
                {
                    if (Convert.ToInt32(cboUserType.SelectedValue) == 1)
                    {
                        frmPaymentList frmEmployeeList = new frmPaymentList(_userBL);
                        frmEmployeeList.Show();
                        Hide();
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect");
                }
            }
            else
            {
                MessageBox.Show("Enter all data");
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
