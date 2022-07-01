using OpenPolytechnic.TechnicalTest.Business.Calculators.Interfaces;
using OpenPolytechnic.TechnicalTest.Business.Promotions.Discounts.Interface;
using OpenPolytechnic.TechnicalTest.Business.ShoppingCart.Interfaces;
using OpenPolytechnic.TechnicalTest.Model.Customer.Interface;
using OpenPolytechnic.TechnicalTest.Model.StockItem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenPolytechnic.TechnicalTest.Business.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IEnumerable<ICalculator> calculators;
        private readonly IDiscountService discountService;

        public ShoppingCartService(
            IEnumerable<ICalculator> calculators,
            IDiscountService discountService)
        {
            this.calculators = calculators;
            this.discountService = discountService;
        }

        public decimal GetAmountDue(ICustomer user, IEnumerable<IStockItem> cart, decimal giftCardAmount, bool creditCardPurchase)
        {
            var discounts = discountService.GetDiscountsForMonth(DateTime.Now.Month);

            var subtotal = cart.Sum(item => calculators.First(calculator => calculator.Handles(user)).CalculateTotal(cart, discounts));

            subtotal = ApplyGiftCard(subtotal, giftCardAmount);

            if (creditCardPurchase)
            {
                subtotal = ApplyCreditCardFee(subtotal);
            }

            return subtotal;
        }

        public decimal ApplyGiftCard(decimal subtotal, decimal giftCardAmount)
        {
            var result = subtotal - giftCardAmount;
            return result > 0 ? result : 0m;
        } 

        public decimal ApplyCreditCardFee(decimal subtotal)
        {
            return subtotal *= 1.01m;
        }
    }
}
