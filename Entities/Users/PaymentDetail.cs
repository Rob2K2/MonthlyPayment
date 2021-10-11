using System;

namespace Entities.Users
{
    public class PaymentDetail
    {
        public int PaymentID { get; set; }

        public int UserID { get; set; }

        public decimal TotalSalary { get; set; }

        public bool IsPayed { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal Bonus { get; set; }

        public decimal Discounts { get; set; }

        public string PayCode { get; set; }

        public DateTime PaymentDate { get; set; }

        public string TopCode { get; set; }

        public string MidCode { get; set; }

        public string BotCode { get; set; }
    }
}
