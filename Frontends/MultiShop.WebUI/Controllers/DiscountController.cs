using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        public async Task<IActionResult> Index(string code)
        {
            var values = await _discountService.GetByCodeDiscountCouponAsync(code);
            ViewData["codeRate"] = values.Rate;
            return RedirectToAction("Index", "ShoppingCard");
        }
    }
}
