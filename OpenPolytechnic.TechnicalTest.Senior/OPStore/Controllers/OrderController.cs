using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Services.Interfaces;

using Newtonsoft.Json;

namespace OPStore.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public OrderSummary PlaceOrder([FromBody] List<VMOrderSummary> items)
        {

           return this.orderService.PlaceOrder(items);
  
        }
    }
}
