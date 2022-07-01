using OpenPolytechnic.TechnicalTest.Business.Stock.Interfaces;
using OpenPolytechnic.TechnicalTest.Model.StockItem;
using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;

namespace OpenPolytechnic.TechnicalTest.Business.Stock
{
    public class StockItemFactory : IStockItemFactory
    {
        public IStockItem CreateStockItem(int itemId, string displayName, decimal itemCost, bool isClearance = false)
        {
            return new StockItem(itemId, displayName, itemCost, isClearance);
        }
    }
}
