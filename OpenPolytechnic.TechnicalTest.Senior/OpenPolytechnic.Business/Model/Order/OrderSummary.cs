using OpenPolytechnic.Business.Model.Menu;
using OpenPolytechnic.Business.Model.Order.Enum;
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

    public class VMOrderSummary {

        public int Id { get; set; }
        public CustomerType eCustomerType { get; set; }
        public string CustomerType { get; set; }
        public string selectedMenu { get; set; }

        public decimal Cost { get; internal set; }
        public bool ChildrensMenu { get; internal set; }
        public bool CateringMenuItem { get; internal set; }

        public int Quantity { get; set; }

        public decimal OriginalCost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Surcharge { get; set; }
        public decimal DiscountAmount { get; set; }

    }

}
