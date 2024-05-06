using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _CarouselUIDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
