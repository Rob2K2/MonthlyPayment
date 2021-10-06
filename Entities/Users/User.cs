using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Users
{
    public class User
    {
        public int UserID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }
    }
}
