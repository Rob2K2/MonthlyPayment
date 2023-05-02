using Entities.Setting;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Settings
{
    public class SettingsDAL : ISettingsDAL
    {
        public UserExchangeRate GetUserSettings(int userID)
        {
            var userSettings = new UserExchangeRate();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT UserID, CurrencyID " +
                                   "FROM UserExchangeRate " +
                                   "WHERE UserID = @UserID";

                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            userSettings.UserID = Convert.ToInt32(dr["UserID"]);
                            userSettings.CurrencyID = Convert.ToInt32(dr["CurrencyID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userSettings;
        }
    }
}
