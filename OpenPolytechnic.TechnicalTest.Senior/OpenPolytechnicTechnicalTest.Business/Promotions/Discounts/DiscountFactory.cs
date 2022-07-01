using OpenPolytechnic.TechnicalTest.Business.Promotions.Discounts.Interface;
using OpenPolytechnic.TechnicalTest.Enum;
using OpenPolytechnic.TechnicalTest.Model.Promotions;

namespace OpenPolytechnic.TechnicalTest.Business.Promotions.Discounts
{
    public class DiscountFactory : IDiscountFactory
    {
        public Discount CreateDiscount(DiscountMonth month, decimal discountAmount, bool clubMembersOnly)
        {
            return new Discount
            {
                Month = month,
                DiscountAmout = discountAmount,
                ClubMembersOnly = clubMembersOnly
            };
        }
    }
}
