using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.Models;
using OrderManagement.Services;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger<OrdersController> logger;
        private readonly IOrderService orderService;

        public OrdersController(ILogger<OrdersController> logger, IOrderService orderService)
        {
            this.logger = logger;
            this.orderService = orderService;
        }

        [HttpGet("{Id}")]
        public List<Order> Get(int Id)
        {
            var orders = this.orderService.getUserOrders(Id);
            if (orders != null)
                return orders;
            return new List<Order>();
        }
    }
}
