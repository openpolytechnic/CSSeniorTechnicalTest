using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;

namespace OpenPolytechnic.TechnicalTest.Business.Stock.Interfaces
{
    public interface IStockItemFactory
    {
        public IStockItem CreateStockItem(int itemId, string displayName, decimal itemCost, bool isClearance = false);
    }
}
