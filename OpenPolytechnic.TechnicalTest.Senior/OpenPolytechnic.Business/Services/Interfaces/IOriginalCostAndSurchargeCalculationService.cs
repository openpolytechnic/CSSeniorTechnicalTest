using OpenPolytechnic.Business.Model.Order;

namespace OpenPolytechnic.Business.Services.Interfaces
{
    public interface IOriginalCostAndSurchargeCalculationService
    {
        void CalculateOriginalCostAndSurcharge(ref Orders orders);
    }
}
