using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class Location
    {
        public int LocationID { get; set; }
        public string? LocationName { get; set; }
        public string? Address { get; set; }
    }
}
