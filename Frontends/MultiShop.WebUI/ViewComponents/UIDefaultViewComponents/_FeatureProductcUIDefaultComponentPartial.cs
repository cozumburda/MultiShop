using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _FeatureProductcUIDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
