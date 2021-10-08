﻿using Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Users
{
    public interface IUsersDAL
    {
        List<User> GetEmployees();

        List<Payment> GetPayments();

        List<UserType> GetUsersType();

        bool Login(string username, string password, int userType);

        int InsertPaymentList(DateTime paymentDate, string observations);

        void InsertPaymentDetail(PaymentDetail paymentDetail);

        Payment GetPaymentList(int idPayment);

        List<PaymentDetail> GetPaymentDetail(int idPayment);

        void UpdatePaymentList(DateTime paymentDate, string observations, int idPayment);

        void DeletePaymentDetail(int idPayment);

        DataSet RptGetPaymentList(int idPayment);
    }
}