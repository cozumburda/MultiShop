using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _VendorUIDefaultComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;
        public _VendorUIDefaultComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
    }
}
