using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _CategoriesUIDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
