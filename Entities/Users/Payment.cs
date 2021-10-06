using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Users
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Observations { get; set; }
    }
}
