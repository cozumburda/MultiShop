using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _FeatureUIDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;
        public _FeatureUIDefaultComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
