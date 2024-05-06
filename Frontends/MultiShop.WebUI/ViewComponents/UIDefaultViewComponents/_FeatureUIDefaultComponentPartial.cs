using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _FeatureUIDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
