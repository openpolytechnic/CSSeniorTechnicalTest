namespace OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces
{
    public interface IStockItem
    {
        public int ItemId { get; }
        public string DisplayName { get; }
        public decimal ItemCost { get; }
        public bool IsClearance { get; }
    }
}
