using System;
using System.Data;
using System.Data.SqlClient;
using DataAccess;
using DataAccess.Users;
using Xunit;

namespace Tests.CRUDTests
{
    public class UserCRUDTests
    {
        private readonly IDBConnection _connection;
        private readonly UsersDAL _sut;

        public UserCRUDTests()
        {
            // Set up test database connection
            _connection = new SQLServerDBConnection();

            // Create instance of PaymentService class
            _sut = new UsersDAL(_connection);
        }
        
        [Fact]
        public void UpdatePendingPayment_SetsPayedFlagTo1()
        {
            // Arrange
            int userID = 2; // Replace with the ID of a test user in your database
            int paymentID = 86; // Replace with the ID of an unpaid MonthlyPaymentDetail record in your database
            using (var connection = _connection.GetConnection())
            {
                connection.Open();
                // Insert test data into MonthlyPaymentDetail table
                var insertQuery = "INSERT INTO MonthlyPaymentDetail (UserID, PaymentID, Payed) VALUES (@UserID, @PaymentID, 0)";
                var cmd = new SqlCommand(insertQuery, (SqlConnection)connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = paymentID;
                cmd.ExecuteNonQuery();
            }

            // Act
            _sut.UpdatePendingPayment(userID, paymentID);

            // Assert
            using (var connection = _connection.GetConnection())
            {
                connection.Open();
                var selectQuery = "SELECT Payed FROM MonthlyPaymentDetail WHERE UserID = @UserID AND PaymentID = @PaymentID";
                var cmd = new SqlCommand(selectQuery, (SqlConnection)connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = paymentID;
                var payed = (bool)cmd.ExecuteScalar();
                Assert.Equal(true, payed);
            }
        }
    }
}