using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.ShoppingCardViewComponents
{
    public class _BasketTotalAmountComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _BasketTotalAmountComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int rate = 0;
            string codeName = null;
            if (ViewData["codeRate"] != null)
            {
                rate = int.Parse(ViewData["codeRate"].ToString());
                codeName = ViewData["codeName"].ToString();
            }
            var totalValue = await _basketService.GetBasket();
            totalValue.DiscountRate = rate;
            totalValue.DiscountCode = codeName;
            return View(totalValue);
        }
    }
}
