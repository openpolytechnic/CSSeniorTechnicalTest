using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;

namespace OpenPolytechnic.TechnicalTest.Model.StockItem
{
    public class StockItem : IStockItem
    {
        public StockItem(int itemId, string displayName, decimal itemCost, bool isClearance = false)
        {
            ItemId = itemId;
            DisplayName = displayName;
            ItemCost = itemCost;
            IsClearance = isClearance;
        }

        public int ItemId { get; internal set; }

        public string DisplayName { get; internal set; }

        public decimal ItemCost { get; internal set; }

        public bool IsClearance { get; internal set; }
    }
}
