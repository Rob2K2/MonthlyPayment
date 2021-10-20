namespace Entities.Users
{
    public class User
    {
        public int UserID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal Bonus { get; set; }

        public decimal Discounts { get; set; }

        public decimal TotalSalary { get; set; }

        public string Currency { get; set; }

        public decimal CurrencyValue { get; set; }
    }
}
