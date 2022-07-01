using OpenPolytechnic.TechnicalTest.Enum;
using OpenPolytechnic.TechnicalTest.Model.Promotions;

namespace OpenPolytechnic.TechnicalTest.Business.Promotions.Discounts.Interface
{
    public interface IDiscountFactory
    { 
        public Discount CreateDiscount(DiscountMonth month, decimal discountAmount, bool clubMembersOnly);
    }
}
