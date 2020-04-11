using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderAmount { get; set; }
        public string OrderDate { get; set; }
    }
}
