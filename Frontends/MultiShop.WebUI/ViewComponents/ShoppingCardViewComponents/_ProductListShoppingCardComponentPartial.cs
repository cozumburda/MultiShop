using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.ShoppingCardViewComponents
{
    public class _ProductListShoppingCardComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ProductListShoppingCardComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket(null);
            return View(values);
        }
    }
}
