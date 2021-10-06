using Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Users
{
    public class UsersDAL
    {
        public bool Login(string username, string password, int userType)
        {
            bool result = false;

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT * " +
                                   "FROM Users " +
                                   "WHERE LoginName=@loginName AND Password=@password AND UserType=@userType";

                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add("@loginName", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    cmd.Parameters.Add("@userType", SqlDbType.Int).Value = userType;

                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public List<UserType> GetUsersType()
        {
            var usersType = new List<UserType>();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT UserTypeID, Type " +
                                   "FROM UsersType";

                    var cmd = new SqlCommand(query, con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var userType = new UserType
                            {
                                UserTypeID = Convert.ToInt32(dr["UserTypeID"]),
                                Type = dr["Type"].ToString()
                            };
                            usersType.Add(userType);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return usersType;
        }
    }
}
