using OpenPolytechnic.TechnicalTest.Business.Promotions.Discounts.Interface;
using OpenPolytechnic.TechnicalTest.Enum;
using OpenPolytechnic.TechnicalTest.Model.Promotions;
using System.Collections.Generic;
using System.Linq;

namespace OpenPolytechnic.TechnicalTest.Business.Promotions.Discounts
{
    public class DiscountService : IDiscountService
    {
        private IEnumerable<Discount> discountMonths;
        private readonly IDiscountFactory discountMonthFactory;

        public DiscountService(IDiscountFactory discountMonthFactory)
        {
            this.discountMonthFactory = discountMonthFactory;
            discountMonths = CreateDiscountMonths();
        }

        public IEnumerable<Discount> GetDiscountsForMonth(int month)
        {
            return discountMonths.Where(discount => (int)discount.Month == month);
        }

        private IEnumerable<Discount> CreateDiscountMonths()
        {
            return new List<Discount>
            {
                discountMonthFactory.CreateDiscount(DiscountMonth.January, 0.02m, false),
                discountMonthFactory.CreateDiscount(DiscountMonth.July, 0.02m, true)
            };
        }
    }
}
