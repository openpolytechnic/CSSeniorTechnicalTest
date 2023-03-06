using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Services.Interfaces;
using System;

namespace OpenPolytechnic.Business.Services
{
    public class ThursdayDiscountCalculationService : IThursdayDiscountCalculationService
    {
        public decimal discountAmount { get; set; } = 0.02m;

        /// <summary>
        /// This discount only applies when MenuType isn't Weekend and isn't Catering
        /// </summary>
        /// <param name="orders"></param>
        public void CalculateDiscount(ref Orders orders)
        {
            if (orders.MenuType.ToLower().Equals("standard"))
            {
                foreach (var order in orders.IndividualOrders)
                {
                    if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday) 
                    {
                        order.totalDiscount += (order.totalOriginalCost - order.totalDiscount) * discountAmount;
                    }
                }
            }
        }
    }
}
