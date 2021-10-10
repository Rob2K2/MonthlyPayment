using System;

namespace Entities.Users
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Observations { get; set; }
    }
}
