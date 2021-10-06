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

        public List<User> GetEmployees()
        {
            var employees = new List<User>();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT UserID, FirstName, LastName, Email, Salary " +
                                   "FROM Users " +
                                   "WHERE UserType = 2";

                    var cmd = new SqlCommand(query, con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var user = new User
                            {
                                UserID = Convert.ToInt32(dr["UserID"]),
                                Firstname = dr["FirstName"].ToString(),
                                Lastname = dr["LastName"].ToString(),
                                Email = dr["Email"].ToString(),
                                Salary = Convert.ToInt32(dr["Salary"])
                            };
                            employees.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return employees;
        }

        public List<Payment> GetPayments()
        {
            var payments = new List<Payment>();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT PaymentID, PaymentDate, Observations " +
                                   "FROM MonthlyPayment";

                    var cmd = new SqlCommand(query, con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var payment = new Payment
                            {
                                PaymentID = Convert.ToInt32(dr["PaymentID"]),
                                PaymentDate = Convert.ToDateTime(dr["PaymentDate"]),
                                Observations = dr["Observations"].ToString(),

                            };
                            payments.Add(payment);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return payments;
        }
    }
}
