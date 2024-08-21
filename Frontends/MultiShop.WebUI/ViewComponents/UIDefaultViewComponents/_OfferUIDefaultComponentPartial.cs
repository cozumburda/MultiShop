using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _OfferUIDefaultComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;
        public _OfferUIDefaultComponentPartial(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
    }
}
