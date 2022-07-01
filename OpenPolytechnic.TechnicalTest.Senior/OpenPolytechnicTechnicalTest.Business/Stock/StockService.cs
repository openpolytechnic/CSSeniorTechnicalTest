using OpenPolytechnic.TechnicalTest.Business.Stock.Interfaces;
using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;
using System.Collections.Generic;

namespace OpenPolytechnic.TechnicalTest.Business.Stock
{
    public class StockService : IStockService
    {
        private readonly IStockItemFactory stockItemFactory;

        public StockService(IStockItemFactory stockItemFactory)
        {
            this.stockItemFactory = stockItemFactory;
        }

        public IEnumerable<IStockItem> GetStockList()
        {
            return new List<IStockItem>
            {
                stockItemFactory.CreateStockItem(1, "New Super Mario Bros.", 85.95m),
                stockItemFactory.CreateStockItem(2, "Fire Emblem: Three Houses", 75.95m),
                stockItemFactory.CreateStockItem(3, "Metroid Dread", 85.95m),
                stockItemFactory.CreateStockItem(4, "Animal Crossing: New Horizons", 65.95m),
                stockItemFactory.CreateStockItem(5, "Astral Chain", 85.95m),
                stockItemFactory.CreateStockItem(6, "Octopath Traveler", 85.95m),
                stockItemFactory.CreateStockItem(7, "Final Fantasy XII", 85.95m),
                stockItemFactory.CreateStockItem(8, "Ultra Street Fighter II", 55.95m),
                stockItemFactory.CreateStockItem(9, "The Legend of Zelda: Breath of the Wild", 85.95m),
                stockItemFactory.CreateStockItem(10, "Bloodstained", 85.95m),
                stockItemFactory.CreateStockItem(11, "Xenoblade Chronicles", 85.95m),
                stockItemFactory.CreateStockItem(12, "ARMS", 95.95m),
                stockItemFactory.CreateStockItem(13, "Ring Fit Adventure", 95.95m),
                stockItemFactory.CreateStockItem(14, "Mario Kart 8 Deluxe", 85.95m),
                stockItemFactory.CreateStockItem(15, "Mega Man 11", 45.95m),
            };
        }
    }
}
