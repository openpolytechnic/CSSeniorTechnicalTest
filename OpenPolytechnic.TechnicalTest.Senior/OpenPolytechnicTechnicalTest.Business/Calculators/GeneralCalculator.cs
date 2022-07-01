using OpenPolytechnic.TechnicalTest.Business.Calculators.Interfaces;
using OpenPolytechnic.TechnicalTest.Enum;
using OpenPolytechnic.TechnicalTest.Model.Customer.Interface;
using OpenPolytechnic.TechnicalTest.Model.Promotions;
using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPolytechnic.TechnicalTest.Business.Calculators
{
    public class GeneralCalculator : ICalculator
    {
        public decimal CalculateTotal(IEnumerable<IStockItem> cart, IEnumerable<Discount> discounts)
        {
            var clearanceTotal = cart.Where(item => item.IsClearance).Sum(item => item.ItemCost * 0.10m);
            var nonClearanceTotal = cart.Where(item => !item.IsClearance).Sum(item => item.ItemCost);

            var subtotal = clearanceTotal + nonClearanceTotal;

            if (subtotal >= 500)
            {
                subtotal *= 0.05m;
            }

            discounts
                .Where(discount => !discount.ClubMembersOnly)
                .ToList()
                .ForEach(discount => subtotal *= discount.DiscountAmout);

            return subtotal;
        }

        public bool Handles(ICustomer customer)
        {
            return customer.CustomerType == CustomerType.Regular;
        }
    }
}
