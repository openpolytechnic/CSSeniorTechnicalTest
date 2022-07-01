using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;
using System.Collections.Generic;

namespace OpenPolytechnic.TechnicalTest.Business.Stock.Interfaces
{
    public interface IStockService
    {
        public IEnumerable<IStockItem> GetStockList();
    }
}
