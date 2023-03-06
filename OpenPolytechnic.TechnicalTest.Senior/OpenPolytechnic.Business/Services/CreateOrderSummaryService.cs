using OpenPolytechnic.Business.Model.Menu;
using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OpenPolytechnic.Business.Services
{
    public class CreateOrderSummaryService : ICreateOrderSummaryService
    {
        private readonly IMenuService _menuService;

        public CreateOrderSummaryService(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// Create and return order summary
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public OrderSummary Create(ref Orders orders)
        {
            //Get all menu items
            var orderMenuItems = new List<MenuItem>();
            var menu = _menuService.GetMenu(orders.MenuType);
            var menuItemIds = orders.IndividualOrders.SelectMany(a => a.MenuItemIds).ToList();
            menuItemIds.ForEach(id => orderMenuItems.Add(menu.Items.Where(x => x.Id == id).FirstOrDefault()));

            //Build OrderSummary
            var orderSummary = new OrderSummary()
            {
                Items = orderMenuItems,
                OriginalCost = orders.IndividualOrders.Sum(a => a.totalOriginalCost),
                Surcharge = orders.IndividualOrders.Sum(a => a.totalSurcharge),
                DiscountAmount = orders.IndividualOrders.Sum(a => a.totalDiscount),
                TotalCost = orders.IndividualOrders.Sum(a => a.totalOriginalCost)
                            + orders.IndividualOrders.Sum(a => a.totalSurcharge)
                            - orders.IndividualOrders.Sum(a => a.totalDiscount)
            };

            return orderSummary;
        }
    }
}
