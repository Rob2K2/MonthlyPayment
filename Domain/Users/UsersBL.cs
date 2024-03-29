﻿using DataAccess.Users;
using Entities.Setting;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;

namespace Domain.Users
{
    public class UsersBL : IUsersBL
    {
        private readonly IUsersDAL _userDAL;

        public UsersBL(IUsersDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public User Login(string username, string password, int userType)
        {
            return _userDAL.Login(username, password, userType);
        }

        public List<UserType> GetUsersType()
        {
            return _userDAL.GetUsersType();
        }

        public List<User> GetEmployees()
        {
            return _userDAL.GetEmployees();
        }

        public List<Payment> GetPayments()
        {
            return _userDAL.GetPayments();
        }

        public int InsertPaymentList(DateTime paymentDate, string observations)
        {
            return _userDAL.InsertPaymentList(paymentDate, observations);
        }

        public void InsertPaymentDetail(PaymentDetail paymentDetail)
        {
            _userDAL.InsertPaymentDetail(paymentDetail);
        }

        public Payment GetPaymentList(int idPayment)
        {
            return _userDAL.GetPaymentList(idPayment);
        }

        public List<PaymentDetail> GetPaymentDetail(int idPayment)
        {
            return _userDAL.GetPaymentDetail(idPayment);
        }

        public void UpdatePaymentList(DateTime paymentDate, string observations, int idPayment)
        {
            _userDAL.UpdatePaymentList(paymentDate, observations, idPayment);
            _userDAL.DeletePaymentDetail(idPayment);
        }

        public DataSet RptGetPaymentList(int idPayment)
        {
            return _userDAL.RptGetPaymentList(idPayment);
        }

        public List<PaymentDetail> GetEmployeePayments(int idEmployee)
        {
            return _userDAL.GetEmployeePayments(idEmployee);
        }

        public void UpdatePendingPayment(int userID, int paymentID)
        {
            _userDAL.UpdatePendingPayment(userID, paymentID);
        }

        public DataSet RptGetRecipe(int userID, int idPayment)
        {
            return _userDAL.RptGetRecipe(userID, idPayment);
        }

        public List<Currency> GetCurrency()
        {
            return _userDAL.GetCurrency();
        }

        public void UpdateCurrency(int userID, int currencyID)
        {
            _userDAL.UpdateCurrency(userID, currencyID);
        }
    }
}
