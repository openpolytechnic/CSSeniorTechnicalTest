using Microsoft.AspNetCore.Mvc;
using OpenPolytechnic.Business.Model.Menu;
using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Services.Interfaces;
using OpenPolytechnic.Business.Model.Order.Enum;
using System.Linq;
using Microsoft.VisualBasic;

namespace OpenPolytechnic.TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController
    {
        private readonly IMenuService _menuService;

        public OrderController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpPost]
        [Route("place")]
        public OrderSummary PlaceOrders(Orders orders)
        {
            var menuType = orders.MenuType;
            var orderMenu = _menuService.GetMenu(menuType);

            var orderSummaries = orders.IndividualOrders.Select(order => CreateIndividualOrderSummary(order, orderMenu, menuType));

            var allMenuItemIds = orders.IndividualOrders.SelectMany(individualOrder => individualOrder.MenuItemIds);
            var allMenuItems = orderMenu.Items.Where(item => allMenuItemIds.Contains(item.Id));

            var originalCost = orderSummaries.Sum(orderSummary => orderSummary.TotalOriginalCost);
            var surcharge = orderSummaries.Sum(orderSummary => orderSummary.TotalSurcharge);
            var discountAmount = orderSummaries.Sum(orderSummary => orderSummary.TotalDiscount);

            var totalCost = (originalCost + surcharge) - discountAmount;

            var orderSummary = new OrderSummary
            {
                Items = allMenuItems,
                OriginalCost = originalCost,
                Surcharge = surcharge,
                DiscountAmount = discountAmount,
                TotalCost = totalCost,
            };

            return orderSummary;
        }

        private static IndividualOrderSummary CreateIndividualOrderSummary(Order order, Menu orderMenu, string menuType)
        {
            decimal totalSurCharge = 0;
            decimal totalOriginalCost = 0;
            decimal totalDiscount = 0;

            var customerType = order.customerType;
            var menuItems = orderMenu.Items.Where(item => order.MenuItemIds.Contains(item.Id));

            foreach (var menuItem in menuItems)
            {
                if (menuItem.ChildrensMenu && customerType != CustomerType.Child)
                {
                    totalSurCharge += menuItem.Cost * (decimal)0.05;
                }
                totalOriginalCost += menuItem.Cost;
            }

            if (!menuType.ToLower().Equals("catering"))
            {
                if (customerType == CustomerType.SeniorCitizen)
                {
                    var seniorCitizenDiscount = totalOriginalCost * (decimal)0.1m;
                    totalDiscount += seniorCitizenDiscount;
                }

                if (totalOriginalCost > 100)
                {
                    var overHundredDiscount = totalOriginalCost * (decimal)0.05;
                    totalDiscount += overHundredDiscount;
                }

                if (DateAndTime.Today.DayOfWeek == System.DayOfWeek.Thursday)
                {
                    var thursdayDiscount = totalOriginalCost * (decimal)0.02m;
                    totalDiscount += thursdayDiscount;
                }
            }

            return new IndividualOrderSummary
            {
                TotalOriginalCost = totalOriginalCost,
                TotalDiscount = totalDiscount,
                TotalSurcharge = totalSurCharge,
            };
        }
    }
}
