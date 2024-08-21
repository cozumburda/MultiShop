using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _CarouselUIDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;
        public _CarouselUIDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }
    }
}
