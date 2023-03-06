using OpenPolytechnic.Business.Model.Order.Enum;
using System.Collections.Generic;

namespace OpenPolytechnic.Business.Model.Order
{
    public class Order
    {
        public CustomerType customerType { get; set; }
        public List<int> MenuItemIds { get; set; }

        /// <summary>
        /// Total cost of all menu items in this Order
        /// </summary>
        public decimal totalOriginalCost { get; set; }
        
        /// <summary>
        /// Total sucharge of all menu items in this Order from Childrens menu
        /// </summary>
        public decimal totalSurcharge { get; set; }

        /// <summary>
        /// Total discount
        /// </summary>
        public decimal totalDiscount { get; set; }

        /// <summary>
        /// totalCost = totalOriginalCost + totalSurcharge - totalDiscount
        /// </summary>
        public decimal totalCost { get; set; } 
    }
}
