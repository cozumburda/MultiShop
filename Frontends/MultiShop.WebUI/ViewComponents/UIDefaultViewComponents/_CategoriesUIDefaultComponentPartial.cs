using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _CategoriesUIDefaultComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public _CategoriesUIDefaultComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
