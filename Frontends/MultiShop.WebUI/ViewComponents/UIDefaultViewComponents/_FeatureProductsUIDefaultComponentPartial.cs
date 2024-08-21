using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _FeatureProductsUIDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductsUIDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
