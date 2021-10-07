using Entities.Users;
using System.Collections.Generic;

namespace Domain.Users
{
    public interface IUsersBL
    {
        List<User> GetEmployees();

        List<Payment> GetPayments();

        List<UserType> GetUsersType();

        bool Login(string username, string password, int userType);
    }
}