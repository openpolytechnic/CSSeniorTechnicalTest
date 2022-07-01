using OpenPolytechnic.TechnicalTest.Model.Customer.Interface;
using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;
using System.Collections.Generic;

namespace OpenPolytechnic.TechnicalTest.Model.Order
{
    public class CartOrder 
    {
        public IEnumerable<IStockItem> Items { get; set; }
        public ICustomer Customer { get; set; }
        public decimal GiftCardAmount { get; set; }
        public bool CreditCardPurchase { get; set; }
    }
}
