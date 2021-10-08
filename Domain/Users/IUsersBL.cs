using Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;

namespace Domain.Users
{
    public interface IUsersBL
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

        DataSet RptGetPaymentList(int idPayment);
    }
}