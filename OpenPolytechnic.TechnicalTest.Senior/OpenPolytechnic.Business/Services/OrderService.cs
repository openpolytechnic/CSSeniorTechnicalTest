using OpenPolytechnic.Business.Factories;
using OpenPolytechnic.Business.Model.Menu;
using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Model.Order.Enum;
using OpenPolytechnic.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPolytechnic.Business.Services
{
    public class OrderService : IOrderService
    {

        private readonly MenuFactory menuFactory;

        public OrderService()
        {
            menuFactory = new MenuFactory();
        }

        public Order GetOrder(string menuType)
        {
            var order = new Order();



            throw new NotImplementedException();
        }

        public Orders GetOrders(Orders orders)
        {
            MenuService menuService = new MenuService();

            var model = menuService.GetMenu(orders.MenuType);

            throw new NotImplementedException();
        }

        
        public OrderSummary PlaceOrder(List<VMOrderSummary> orders) {

            MenuService menuService = new MenuService();

            OrderSummary os = new OrderSummary();
            List<MenuItem> mi = new List<MenuItem>();

            decimal total = 0;
            decimal origTotal = 0;

            decimal FivePercent=  (decimal)0.05;
            decimal TenPercent = (decimal).10;
            decimal TwoPercent = (decimal).02;

            foreach (var order in orders) {

                order.eCustomerType = Enum.Parse<CustomerType>(order.CustomerType);

                var findItem = menuService
                                .GetMenu(order.selectedMenu)
                                .Items.Where(x => x.Id == order.Id).FirstOrDefault();

                //// use db or server side data. not the client side data.
                if (findItem != null) {

                    order.Cost = Math.Round(findItem.Cost * order.Quantity, 2);
                    
                    order.ChildrensMenu = findItem.ChildrensMenu;
                    order.CateringMenuItem = findItem.CateringMenuItem;
                }

                total = order.Cost;

                if (order.selectedMenu != "catering")
                {
                    //// senior
                    if (order.eCustomerType == CustomerType.SeniorCitizen)
                    {

                        order.DiscountAmount = order.Cost * TenPercent;
                        total = order.Cost - (order.Cost * TenPercent);

                    }

                    ///// steps for the discount and surcharge
                    if (order.eCustomerType != CustomerType.Child && order.ChildrensMenu)
                    {

                        order.Surcharge = total * FivePercent;

                        total += order.Surcharge;

                    }

                    if (total > 100)
                    {

                        order.DiscountAmount += (total * FivePercent);

                        total -= (total * FivePercent);
                        

                    }

                    if (order.selectedMenu == "standard" && DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                    {

                        order.DiscountAmount += (total * TwoPercent);

                        total = Math.Round(total - (total * TwoPercent), 2);

                    }

                }

                order.TotalCost = total;
                order.OriginalCost = order.Cost;

                //// save data to OpenPolytechnic model
                mi.Add(new MenuItem(order.Id, findItem.Name, findItem.Description, order.Cost,
                    findItem.ItemType, findItem.ChildrensMenu, findItem.CateringMenuItem));

                
            }

            os.Items = mi;

            os.TotalCost = orders.Sum(x => x.TotalCost);
            os.OriginalCost = orders.Sum(x => x.OriginalCost);
            os.Surcharge = orders.Sum(x => x.Surcharge);
            os.DiscountAmount = orders.Sum(x => x.DiscountAmount);

            return os;
        
        }
    }
}
