using Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Users
{
    public class UsersDAL : IUsersDAL
    {
        public User Login(string username, string password, int userType)
        {
            var user = new User();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT UserID, FirstName, Lastname " +
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
                            user.UserID = Convert.ToInt32(dr["UserID"]);
                            user.Firstname = dr["FirstName"].ToString();
                            user.Lastname = dr["LastName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
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
                throw ex;
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
                    string query = "SELECT u.UserID, FirstName, LastName, Email, BasicSalary, Bonus, Discounts, (BasicSalary + Bonus - Discounts) TotalSalary " +
                                   "FROM Users u " +
                                   "INNER JOIN SalaryCalc s ON s.UserID = u.UserID " +
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
                                BasicSalary = Convert.ToDecimal(dr["BasicSalary"]),
                                Bonus = Convert.ToDecimal(dr["Bonus"]),
                                Discounts = Convert.ToDecimal(dr["Discounts"]),
                                TotalSalary = Convert.ToDecimal(dr["TotalSalary"])
                            };
                            employees.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }

            return payments;
        }

        public int InsertPaymentList(DateTime paymentDate, string observations)
        {
            int paymentID = 0;

            try
            {
                using (var connection = DBConnection.SqlServerConexion())
                {
                    connection.Open();
                    var query = "INSERT INTO MonthlyPayment(PaymentDate, Observations) " +
                                "VALUES(@PaymentDate, @Observations) " +
                                "SELECT SCOPE_IDENTITY()";

                    var cmd = new SqlCommand(query, connection);

                    cmd.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = paymentDate;
                    cmd.Parameters.Add("@Observations", SqlDbType.VarChar).Value = observations;

                    paymentID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return paymentID;
        }

        public void InsertPaymentDetail(PaymentDetail paymentDetail)
        {
            try
            {
                using (var connection = DBConnection.SqlServerConexion())
                {
                    connection.Open();
                    var query = "INSERT INTO MonthlyPaymentDetail(PaymentID, UserID, TotalSalary, Payed, PayCode, topCode, midCode, botCode) " +
                                "VALUES(@PaymentID, @UserID, @TotalSalary, @Payed, @PayCode, @topCode, @midCode, @botCode)";

                    var cmd = new SqlCommand(query, connection);

                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = paymentDetail.PaymentID;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = paymentDetail.UserID;
                    cmd.Parameters.Add("@TotalSalary", SqlDbType.Decimal).Value = paymentDetail.TotalSalary;
                    cmd.Parameters.Add("@Payed", SqlDbType.Bit).Value = paymentDetail.IsPayed;
                    cmd.Parameters.Add("@PayCode", SqlDbType.VarChar).Value = paymentDetail.PayCode;
                    cmd.Parameters.Add("@topCode", SqlDbType.VarChar).Value = paymentDetail.TopCode;
                    cmd.Parameters.Add("@midCode", SqlDbType.VarChar).Value = paymentDetail.MidCode;
                    cmd.Parameters.Add("@botCode", SqlDbType.VarChar).Value = paymentDetail.BotCode;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Payment GetPaymentList(int idPayment)
        {
            var payment = new Payment();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT PaymentID, PaymentDate, Observations " +
                                   "FROM MonthlyPayment " +
                                   "WHERE PaymentID=@PaymentID";

                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = idPayment;

                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            payment.PaymentID = Convert.ToInt32(dr["PaymentID"]);
                            payment.PaymentDate = Convert.ToDateTime(dr["PaymentDate"]);
                            payment.Observations = dr["Observations"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return payment;
        }

        public List<PaymentDetail> GetPaymentDetail(int idPayment)
        {
            var paymentsDetail = new List<PaymentDetail>();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT PaymentID, u.UserID, u.FirstName Name, u.LastName, u.Email, sc.BasicSalary, sc.Bonus, sc.Discounts, (sc.BasicSalary + sc.Bonus - sc.Discounts) TotalSalary, Payed " +
                                   "FROM MonthlyPaymentDetail mpd " +
                                   "INNER JOIN Users u ON u.UserID = mpd.UserID " +
                                   "INNER JOIN SalaryCalc sc ON sc.UserID = u.UserID " +
                                   "WHERE PaymentID = @PaymentID";

                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = idPayment;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var paymentDetail = new PaymentDetail
                            {
                                PaymentID = Convert.ToInt32(dr["PaymentID"]),
                                UserID = Convert.ToInt32(dr["UserID"]),
                                Name = dr["Name"].ToString(),
                                Lastname = dr["LastName"].ToString(),
                                Email = dr["Email"].ToString(),
                                BasicSalary = Convert.ToDecimal(dr["BasicSalary"]),
                                Bonus = Convert.ToDecimal(dr["Bonus"]),
                                Discounts = Convert.ToDecimal(dr["Discounts"]),
                                TotalSalary = Convert.ToDecimal(dr["TotalSalary"]),
                                IsPayed = Convert.ToBoolean(dr["Payed"])
                            };
                            paymentsDetail.Add(paymentDetail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return paymentsDetail;
        }

        public void UpdatePaymentList(DateTime paymentDate, string observations, int idPayment)
        {
            try
            {
                using (var connection = DBConnection.SqlServerConexion())
                {
                    connection.Open();
                    var query = "UPDATE MonthlyPayment " +
                                "SET PaymentDate = @PaymentDate, Observations = @Observations " +
                                "WHERE PaymentID = @PaymentID";

                    var cmd = new SqlCommand(query, connection);

                    cmd.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = paymentDate;
                    cmd.Parameters.Add("@Observations", SqlDbType.VarChar).Value = observations;
                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = idPayment;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeletePaymentDetail(int idPayment)
        {
            try
            {
                using (var connection = DBConnection.SqlServerConexion())
                {
                    connection.Open();

                    var query = "DELETE FROM MonthlyPaymentDetail " +
                                "WHERE PaymentID = @PaymentID";

                    var cmd = new SqlCommand(query, connection);

                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = idPayment;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet RptGetPaymentList(int idPayment)
        {
            DataSet ds = new DataSet();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT mp.PaymentID, u.UserID, u.FirstName Name, u.LastName, u.Email, sc.BasicSalary, sc.Bonus, sc.Discounts, (sc.BasicSalary + sc.Bonus - sc.Discounts) TotalSalary, Payed, mp.PaymentDate " +
                                   "FROM MonthlyPaymentDetail mpd " +
                                   "INNER JOIN Users u ON u.UserID = mpd.UserID " +
                                   "INNER JOIN SalaryCalc sc ON sc.UserID = u.UserID " +
                                   "INNER JOIN MonthlyPayment mp ON mp.PaymentID = mpd.PaymentID " +
                                   "WHERE mp.PaymentID = @PaymentID";

                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = idPayment;

                    cmd.Prepare();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "rpt_GetPayment");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public List<PaymentDetail> GetEmployeePayments(int idEmployee)
        {
            var paymentsDetail = new List<PaymentDetail>();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT mp.PaymentDate, BasicSalary, Bonus, Discounts, (BasicSalary + Bonus - Discounts) TotalSalary, Payed, Paycode, mp.PaymentID " +
                                   "FROM MonthlyPaymentDetail mpd " +
                                   "INNER JOIN MonthlyPayment mp ON mp.PaymentID = mpd.PaymentID " +
                                   "WHERE UserID = @UserID";

                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = idEmployee;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var paymentDetail = new PaymentDetail
                            {
                                PaymentID = Convert.ToInt32(dr["PaymentID"]),
                                PaymentDate = Convert.ToDateTime(dr["PaymentDate"]),
                                BasicSalary = Convert.ToDecimal(dr["BasicSalary"]),
                                Bonus = Convert.ToDecimal(dr["Bonus"]),
                                Discounts = Convert.ToDecimal(dr["Discounts"]),
                                TotalSalary = Convert.ToDecimal(dr["TotalSalary"]),
                                IsPayed = Convert.ToBoolean(dr["Payed"]),
                                PayCode = dr["Paycode"].ToString()
                            };
                            paymentsDetail.Add(paymentDetail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return paymentsDetail;
        }

        public void UpdatePendingPayment(int userID, int paymentID)
        {
            try
            {
                using (var connection = DBConnection.SqlServerConexion())
                {
                    connection.Open();
                    var query = "UPDATE MonthlyPaymentDetail " +
                                "SET Payed = 1 " +
                                "WHERE UserID = @UserID AND PaymentID = @PaymentID";

                    var cmd = new SqlCommand(query, connection);

                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = paymentID;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet RptGetRecipe(int userID, int idPayment)
        {
            DataSet ds = new DataSet();

            try
            {
                using (var con = DBConnection.SqlServerConexion())
                {
                    con.Open();
                    string query = "SELECT mp.PaymentDate, mpd.Name, mpd.Lastname, (BasicSalary + Bonus - Discounts) TotalSalary, Paycode, mp.PaymentID, mpd.UserID, topCode, midCode, botCode " +
                                   "FROM MonthlyPaymentDetail mpd " +
                                   "INNER JOIN MonthlyPayment mp ON mp.PaymentID = mpd.PaymentID " +
                                   "WHERE UserID = @UserID AND mp.PaymentID = @PaymentID";

                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = idPayment;

                    cmd.Prepare();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "rpt_GetRecipe");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }
    }
}
