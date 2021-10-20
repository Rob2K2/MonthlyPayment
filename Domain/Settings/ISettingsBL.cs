using Entities.Setting;

namespace Domain.Settings
{
    public interface ISettingsBL
    {
        UserExchangeRate GetUserSettings(int userID);
    }
}