using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Repository
{
    public class OrderRepository
    {
        private static Dictionary<int, List<Order>> userOrders = new Dictionary<int, List<Order>>
        {
            {1,new List<Order>
                {
                 new Order{OrderId = 1, OrderAmount = 250, OrderDate = "27-Apr-2020"},
                 new Order{OrderId = 2, OrderAmount = 450, OrderDate = "28-Apr-2020"}
                }
            },
            {2,new List<Order>
                {
                 new Order{OrderId = 3, OrderAmount = 290, OrderDate = "24-Apr-2020"},
                 new Order{OrderId = 4, OrderAmount = 370, OrderDate = "29-Apr-2020" }
                }
            }
        };

        public static List<Order> getOrderDetails(int userId)
        {
            if (userOrders.ContainsKey(userId))
            {
                List<Order> orders = new List<Order>();
                userOrders.TryGetValue(userId, out orders);
                return orders;
            }
            return null;
        }
    }
}
