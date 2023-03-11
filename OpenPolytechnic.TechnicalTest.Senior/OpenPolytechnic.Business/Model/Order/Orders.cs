using OpenPolytechnic.Business.Model.Menu.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenPolytechnic.Business.Model.Order
{
    public class Orders
    {
        public string MenuType { get; set; } 
        public IEnumerable<Order> IndividualOrders { get; set; }
    }
}
