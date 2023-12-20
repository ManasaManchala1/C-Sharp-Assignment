using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class Payments
    {
        public int PaymentID { get; set; }
        public int CourierID { get; set; }
        public int LocationID { get; set; }
        public double Amount { get; set; }
        public string? PaymentDate { get; set; }
    }
}
