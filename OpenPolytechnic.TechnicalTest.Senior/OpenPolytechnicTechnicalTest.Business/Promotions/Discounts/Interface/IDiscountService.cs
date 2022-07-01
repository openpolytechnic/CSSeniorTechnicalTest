using OpenPolytechnic.TechnicalTest.Model.Promotions;
using System.Collections.Generic;

namespace OpenPolytechnic.TechnicalTest.Business.Promotions.Discounts.Interface
{
    public interface IDiscountService
    {
        public IEnumerable<Discount> GetDiscountsForMonth(int month);
    }
}
