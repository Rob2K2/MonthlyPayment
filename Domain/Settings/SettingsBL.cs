using DataAccess.Settings;
using Entities.Setting;

namespace Domain.Settings
{
    public class SettingsBL : ISettingsBL
    {
        private readonly ISettingsDAL _settingsDAL;

        public SettingsBL(ISettingsDAL settingsDAL)
        {
            _settingsDAL = settingsDAL;
        }

        public UserExchangeRate GetUserSettings(int userID)
        {
            return _settingsDAL.GetUserSettings(userID);
        }
    }
}
