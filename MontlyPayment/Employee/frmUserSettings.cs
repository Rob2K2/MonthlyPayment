using Domain.Settings;
using Domain.Users;
using System;
using System.Windows.Forms;

namespace MontlyPayment
{
    public partial class frmUserSettings : Form
    {
        private readonly IUsersBL _userBL;
        private readonly ISettingsBL _settingsBL;
        
        public int IdUser { get; set; }

        public frmUserSettings(IUsersBL userBL, ISettingsBL settingsBL)
        {
            _userBL = userBL;
            _settingsBL = settingsBL;

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
            cboCurrency.SelectedValue = _settingsBL.GetUserSettings(IdUser).CurrencyID;
        }

        private void FillComboCurrency()
        {
            cboCurrency.DataSource = _userBL.GetCurrency();
            cboCurrency.ValueMember = "CurrencyID";
            cboCurrency.DisplayMember = "Name";
        }
    }
}
