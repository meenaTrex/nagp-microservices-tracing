using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aggregator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aggregator.Services;

namespace Aggregator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ControllerBase
    {

        private readonly ILogger<OrderDetailsController> logger;
        private readonly IAggregatorService aggregatorService;

        public OrderDetailsController(ILogger<OrderDetailsController> logger, IAggregatorService aggregatorService)
        {
            this.logger = logger;
            this.aggregatorService = aggregatorService;
        }


        [HttpGet("{Id}")]
        public async Task<UserOrder> Get(int Id)
        {
            var userOrderDetails = await this.aggregatorService.getUserOrderDetails(Id);
            if (userOrderDetails == null)
                return new UserOrder();
            return userOrderDetails;
        }
    }
}
