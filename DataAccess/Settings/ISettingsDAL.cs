using Entities.Setting;

namespace DataAccess.Settings
{
    public interface ISettingsDAL
    {
        UserExchangeRate GetUserSettings(int userID);
    }
}