using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _SpecialOfferUIDefaultComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;
        public _SpecialOfferUIDefaultComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
