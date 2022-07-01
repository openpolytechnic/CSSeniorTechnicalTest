using OpenPolytechnic.TechnicalTest.Business.Calculators.Interfaces;
using OpenPolytechnic.TechnicalTest.Enum;
using OpenPolytechnic.TechnicalTest.Model.Customer.Interface;
using OpenPolytechnic.TechnicalTest.Model.Promotions;
using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OpenPolytechnic.TechnicalTest.Business.Calculators
{
    public class ClubMemberCalculator : ICalculator
    {
        public decimal CalculateTotal(IEnumerable<IStockItem> cart, IEnumerable<Discount> discounts)
        {
            var clearanceTotal = cart.Where(item => item.IsClearance).Sum(item => item.ItemCost * 0.10m);
            var nonClearanceTotal = cart.Where(item => !item.IsClearance).Sum(item => item.ItemCost * 0.05m);

            var subtotal = clearanceTotal + nonClearanceTotal;

            if (subtotal >= 500)
            {
                subtotal *= 0.05m;
            }

            discounts
                .ToList()
                .ForEach(discount => subtotal *= discount.DiscountAmout);

            return subtotal;
        }

        public bool Handles(ICustomer customer)
        {
            return customer.CustomerType == CustomerType.ClubMember;
        }
    }
}
