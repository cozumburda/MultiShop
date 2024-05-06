using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UIDefaultViewComponents
{
    public class _SpecialOfferUIDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
