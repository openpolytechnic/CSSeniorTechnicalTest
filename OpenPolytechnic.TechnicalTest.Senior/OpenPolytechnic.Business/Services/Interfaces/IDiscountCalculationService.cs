using OpenPolytechnic.Business.Model.Order;

namespace OpenPolytechnic.Business.Services.Interfaces
{
    public interface IDiscountCalculationService
    {
        decimal discountAmount { set; }
        void CalculateDiscount(ref Orders orders);
    }
}
