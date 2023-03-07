using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Services.Interfaces;

namespace OpenPolytechnic.Business.Services
{
    public class OverHundredDiscountCalculationService : IOverHundredDiscountCalculationService
    {
        public decimal discountAmount { get; set; } = 0.05m;
        public void CalculateDiscount(ref Orders orders)
        {
            if (!orders.MenuType.ToLower().Equals("catering")) 
            { 
                foreach (var order in orders.IndividualOrders)
                {
                    if (order.totalOriginalCost > 100)
                    {
                        order.totalDiscount += (order.totalOriginalCost - order.totalDiscount) * discountAmount;
                    }
                }
            }
        }
    }
}
