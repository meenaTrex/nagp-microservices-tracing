using Aggregator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class AggregatorService : IAggregatorService
    {
        private const string UserUrl = "https://localhost:5001/user/";
        private const string OrdersUrl = "https://localhost:5003/orders/";
        public async Task<User> getUserDetails(int userId)
        {
            string url = null;
            url = Environment.GetEnvironmentVariable("User_URL");
            if (url == null)
            {
                url = UserUrl;
            }
            url = url + userId;
            
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(data);
            return user;
        }

        public async Task<List<Order>> getOrderDetails(int userId)
        {
            string url = null;
            url = Environment.GetEnvironmentVariable("Order_URL");
            if (url == null)
            {
                url = OrdersUrl;
            }
            url = url + userId;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<List<Order>>(data);
            return order;
        }

        public async Task<UserOrder> getUserOrderDetails(int Id)
        {
            var user = await getUserDetails(Id);
            if (user == null)
                return null;
            var order = await getOrderDetails(Id);
            return new UserOrder()
            {
                userDetails = user,
                orderDetails = order
            };
            
        }
    }
}
