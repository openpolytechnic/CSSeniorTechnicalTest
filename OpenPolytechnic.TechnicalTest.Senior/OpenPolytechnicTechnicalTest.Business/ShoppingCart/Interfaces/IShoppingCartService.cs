using OpenPolytechnic.TechnicalTest.Model.Customer.Interface;
using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;
using System.Collections.Generic;

namespace OpenPolytechnic.TechnicalTest.Business.ShoppingCart.Interfaces
{
    public interface IShoppingCartService
    {
        public decimal GetAmountDue(ICustomer user, IEnumerable<IStockItem> cart, decimal giftCardAmount, bool creditCardPurchase);
    }
}
