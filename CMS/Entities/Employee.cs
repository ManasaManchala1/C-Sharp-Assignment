using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? Role { get; set; }
        public double Salary { get; set; }
    }
}
