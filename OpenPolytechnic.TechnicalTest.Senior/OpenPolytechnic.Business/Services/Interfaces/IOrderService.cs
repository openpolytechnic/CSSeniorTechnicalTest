using OpenPolytechnic.Business.Model.Order;
using System.Collections.Generic;

namespace OpenPolytechnic.Business.Services.Interfaces
{
    public interface IOrderService
    {
        public Order GetOrder(string menuType);

        public Orders GetOrders(Orders orders);

        public OrderSummary PlaceOrder(List<VMOrderSummary> orders);

    }
}
