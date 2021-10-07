using Entities.Users;
using System.Collections.Generic;

namespace DataAccess.Users
{
    public interface IUsersDAL
    {
        List<User> GetEmployees();

        List<Payment> GetPayments();

        List<UserType> GetUsersType();

        bool Login(string username, string password, int userType);
    }
}