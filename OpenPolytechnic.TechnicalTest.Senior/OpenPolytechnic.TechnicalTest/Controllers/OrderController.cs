using Microsoft.AspNetCore.Mvc;
using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Services.Interfaces;
using System;

namespace OpenPolytechnic.TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController
    {
        private readonly IOriginalCostAndSurchargeCalculationService _originalCostAndSurchargeCalculationService;
        private readonly ISeniorDiscountCalculationService _seniorDiscountCalculationService;
        private readonly IOverHundredDiscountCalculationService _overHundredDiscountCalculationService;
        private readonly IThursdayDiscountCalculationService _thursdayDiscountCalculationService;
        private readonly ICreateOrderSummaryService _createOrderSummaryService;

        public OrderController(
            IOriginalCostAndSurchargeCalculationService originalCostAndSurchargeCalculationService,
            ISeniorDiscountCalculationService seniorDiscountCalculationService,
            IOverHundredDiscountCalculationService overHundredDiscountCalculationService,
            IThursdayDiscountCalculationService thursdayDiscountCalculationService,
            ICreateOrderSummaryService createOrderSummaryService)
        {
            _originalCostAndSurchargeCalculationService = originalCostAndSurchargeCalculationService;
            _seniorDiscountCalculationService = seniorDiscountCalculationService;
            _overHundredDiscountCalculationService = overHundredDiscountCalculationService;
            _thursdayDiscountCalculationService = thursdayDiscountCalculationService;
            _createOrderSummaryService = createOrderSummaryService;
        }

        [HttpPost]
        [Route("place")]
        public OrderSummary PlaceOrders(Orders orders)
        {
            try
            {
                ProcessOrder(ref orders);

                return _createOrderSummaryService.Create(ref orders);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Process the placed order
        /// </summary>
        /// <param name="orders"></param>
        private void ProcessOrder(ref Orders orders)
        {
            //Calculate original cost and if any surcharge
            _originalCostAndSurchargeCalculationService.CalculateOriginalCostAndSurcharge(ref orders);

            //Calculate senior discount
            _seniorDiscountCalculationService.CalculateDiscount(ref orders);

            //Calculate over hundred discount
            _overHundredDiscountCalculationService.CalculateDiscount(ref orders);

            //Calculate Thursday discount
            _thursdayDiscountCalculationService.CalculateDiscount(ref orders);
        }
    }
}
