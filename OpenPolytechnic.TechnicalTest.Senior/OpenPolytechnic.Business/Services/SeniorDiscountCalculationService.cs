using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Services.Interfaces;

namespace OpenPolytechnic.Business.Services
{
    public class SeniorDiscountCalculationService : ISeniorDiscountCalculationService
    {
        public decimal discountAmount { get; set; } = 0.1m;
        public void CalculateDiscount(ref Orders orders)
        {
            if (!orders.MenuType.ToLower().Equals("catering"))
            {
                foreach (var order in orders.IndividualOrders)
                {
                    if (order.customerType == Model.Order.Enum.CustomerType.SeniorCitizen)
                    {
                        order.totalDiscount += (order.totalOriginalCost - order.totalDiscount) * discountAmount;
                    }
                }
            }
        }
    }
}
