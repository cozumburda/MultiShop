using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public _ProductListComponentPartial(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            if (id == null)
            {
                var values = await _productService.GetProductsWithCategoryAsync();
                return View(values);
            }
            else
            {
                var values2 = await _categoryService.GetByIdCategoryAsync(id);

                var values = await _categoryService.GetProductsByCategoryIdAsync(id);
                ViewBag.ct = values.Count > 0 ? values2.CategoryName + " " + "Kategorisindeki Ürünler" : values2.CategoryName + " " + "Kategorisinde Henüz Ürün Yok";
                return View(values);
            }
        }
    }
}
