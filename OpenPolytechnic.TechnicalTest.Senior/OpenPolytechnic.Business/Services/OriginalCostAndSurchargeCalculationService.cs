using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Services.Interfaces;
using System.Linq;

namespace OpenPolytechnic.Business.Services
{
    public class OriginalCostAndSurchargeCalculationService : IOriginalCostAndSurchargeCalculationService
    {
        private readonly IMenuService _menuService;
        public OriginalCostAndSurchargeCalculationService(IMenuService menuService)
        {
            _menuService = menuService; 
        }

        public void CalculateOriginalCostAndSurcharge(ref Orders orders)
        {
            var menu = _menuService.GetMenu(orders.MenuType);
            foreach (var order in orders.IndividualOrders)
            {
                decimal totalSurcharge = 0;
                decimal totalOriginalCost = 0;
                var orderItems = menu.Items.Where(x => order.MenuItemIds.Contains(x.Id)).Select(a => a);
                foreach (var orderItem in orderItems)
                {
                    if (orderItem.ChildrensMenu && order.customerType != Model.Order.Enum.CustomerType.Child)
                    {
                        totalSurcharge += orderItem.Cost * (decimal)0.05;
                    }
                    totalOriginalCost += orderItem.Cost;
                }
                order.totalSurcharge = totalSurcharge;
                order.totalOriginalCost = totalOriginalCost;
            }
        }
    }
}
