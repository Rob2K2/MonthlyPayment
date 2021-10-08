using Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Users
{
    public class UsersDAL : IUsersDAL
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
                throw ex;
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
                    var query = "INSERT INTO MonthlyPaymentDetail(PaymentID, UserID, TotalSalary, Payed, Name, Lastname, Email, BasicSalary, Bonus, Discounts) " +
                                "VALUES(@PaymentID, @UserID, @TotalSalary, @Payed, @Name, @Lastname, @Email, @BasicSalary, @Bonus, @Discounts)";

                    var cmd = new SqlCommand(query, connection);

                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = paymentDetail.PaymentID;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = paymentDetail.UserID;
                    cmd.Parameters.Add("@TotalSalary", SqlDbType.Decimal).Value = paymentDetail.TotalSalary;
                    cmd.Parameters.Add("@Payed", SqlDbType.Bit).Value = paymentDetail.IsPayed;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = paymentDetail.Name;
                    cmd.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = paymentDetail.Lastname;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = paymentDetail.Email;
                    cmd.Parameters.Add("@BasicSalary", SqlDbType.Decimal).Value = paymentDetail.BasicSalary;
                    cmd.Parameters.Add("@Bonus", SqlDbType.Decimal).Value = paymentDetail.Bonus;
                    cmd.Parameters.Add("@Discounts", SqlDbType.Decimal).Value = paymentDetail.Discounts;


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
                    string query = "SELECT PaymentID, UserID, Name, LastName, Email, BasicSalary, Bonus, Discounts, (BasicSalary + Bonus - Discounts) TotalSalary, Payed " +
                                   "FROM MonthlyPaymentDetail " +
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
                    string query = "SELECT * " +
                                   "FROM MonthlyPayment m " +
                                   "INNER JOIN MonthlyPaymentDetail d ON d.PaymentID = m.PaymentID " +
                                   "WHERE m.PaymentID = @PaymentID";

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
    }
}
