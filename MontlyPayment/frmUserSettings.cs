using Domain.Users;
using System;
using System.Windows.Forms;

namespace MontlyPayment
{
    public partial class frmUserSettings : Form
    {
        private readonly IUsersBL _userBL;
        
        public int IdUser { get; set; }

        public frmUserSettings(IUsersBL userBL)
        {
            _userBL = userBL;

            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var currencyID = (int)cboCurrency.SelectedValue;
            _userBL.UpdateCurrency(IdUser, currencyID);


            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmUserSettings_Load(object sender, EventArgs e)
        {
            IdUser = frmEmployeePayments.user.UserID;
            FillComboCurrency();
        }

        private void FillComboCurrency()
        {
            cboCurrency.DataSource = _userBL.GetCurrency();
            cboCurrency.ValueMember = "CurrencyID";
            cboCurrency.DisplayMember = "Name";
        }
    }
}
