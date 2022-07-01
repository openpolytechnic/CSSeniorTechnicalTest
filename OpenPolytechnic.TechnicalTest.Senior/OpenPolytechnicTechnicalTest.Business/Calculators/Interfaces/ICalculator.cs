using OpenPolytechnic.TechnicalTest.Model.Customer.Interface;
using OpenPolytechnic.TechnicalTest.Model.Promotions;
using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;
using System.Collections.Generic;

namespace OpenPolytechnic.TechnicalTest.Business.Calculators.Interfaces
{
    public interface ICalculator
    {
        public bool Handles(ICustomer customer);
        public decimal CalculateTotal(IEnumerable<IStockItem> cart, IEnumerable<Discount> discounts);
    }
}
