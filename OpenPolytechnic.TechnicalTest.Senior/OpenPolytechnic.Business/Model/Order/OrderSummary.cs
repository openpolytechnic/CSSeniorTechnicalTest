using OpenPolytechnic.Business.Model.Menu;
using System.Collections.Generic;

namespace OpenPolytechnic.Business.Model.Order
{
    public class OrderSummary
    {
        public IEnumerable<MenuItem> Items { get; set; }
        public decimal OriginalCost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Surcharge { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
