using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class UserOrder
    {
        public User userDetails { get; set; }
        public List<Order> orderDetails { get; set; }
    }
}
