using Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public interface IAggregatorService
    {
        Task<User> getUserDetails(int userId);
        Task<List<Order>> getOrderDetails(int userId);
        Task<UserOrder> getUserOrderDetails(int Id);
    }
}
