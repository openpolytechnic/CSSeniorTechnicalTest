using Microsoft.AspNetCore.Mvc;
using OpenPolytechnic.Business.Model.Order;

namespace OpenPolytechnic.TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController
    {

        public OrderController()
        {
        }

        [HttpPost]
        [Route("place")]
        public OrderSummary PlaceOrders(Orders orders)
        {
            return null;
        }
    }
}
