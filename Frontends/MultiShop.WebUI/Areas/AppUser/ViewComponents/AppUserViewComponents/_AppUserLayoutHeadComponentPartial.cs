using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.AppUser.ViewComponents.AppUserViewComponents
{
    public class _AppUserLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
