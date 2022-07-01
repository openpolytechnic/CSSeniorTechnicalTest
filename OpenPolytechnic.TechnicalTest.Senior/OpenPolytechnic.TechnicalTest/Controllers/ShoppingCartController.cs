using Microsoft.AspNetCore.Mvc;
using OpenPolytechnic.TechnicalTest.Business.ShoppingCart.Interfaces;
using OpenPolytechnic.TechnicalTest.Model.Order;

namespace OpenPolytechnic.TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        [Route("submit")]
        public decimal SubmitOrder(CartOrder cartOrder)
        {
            return shoppingCartService.GetAmountDue(cartOrder.Customer, cartOrder.Items, cartOrder.GiftCardAmount, cartOrder.CreditCardPurchase);
        }
    }
}
