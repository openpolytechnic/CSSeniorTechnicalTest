using OpenPolytechnic.Business.Model.Order;

namespace OpenPolytechnic.Business.Services.Interfaces
{
    public interface ICreateOrderSummaryService
    {
        OrderSummary Create(ref Orders orders);
    }
}
