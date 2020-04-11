using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Models;
using OrderManagement.Repository;

namespace OrderManagement.Services
{
    public class OrderService : IOrderService
    {
        public List<Order> getUserOrders(int userId)
        {
            return OrderRepository.getOrderDetails(userId);
        }
    }
}
