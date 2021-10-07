﻿using DataAccess.Users;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class UsersBL : IUsersBL
    {
        private readonly UsersDAL userDAL = new UsersDAL();

        public bool Login(string username, string password, int userType)
        {
            return userDAL.Login(username, password, userType);
        }

        public List<UserType> GetUsersType()
        {
            return userDAL.GetUsersType();
        }

        public List<User> GetEmployees()
        {
            return userDAL.GetEmployees();
        }

        public List<Payment> GetPayments()
        {
            return userDAL.GetPayments();
        }
    }
}
