using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    [Route("ShoppingCard")]
    public class ShoppingCardController : Controller
    {

        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IDiscountService _discountService;

        public ShoppingCardController(IProductService productService, IBasketService basketService, IDiscountService discountService)
        {
            _productService = productService;
            _basketService = basketService;
            _discountService = discountService;
        }
        [Route("Index")]
        [Route("Index/{code}")]
        public async Task<IActionResult> Index(string? code)
        {
            ViewBag.Dr1 = "Anasayfa";
            ViewBag.Dr2 = "/Default/Index/";
            ViewBag.Dr3 = "Ürünler";
            ViewBag.Dr4 = "/ProductList/Index/";
            ViewBag.Dr5 = "Sepetim";
            if (code != null)
            {
                var values = await _discountService.GetByCodeDiscountCouponAsync(code);
                ViewData["codeRate"] = values.Rate;
                ViewData["codeName"] = values.Code;
                ViewBag.codeName = values.Code;
            }
            return View();
        }

        [Route("AddBasketItem/{productId}")]
        [Route("AddBasketItem/")]
        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var values = await _productService.GetByIdProductAsync(productId);
            var items = new BasketItemDto
            {
                ProductId = values.ProductID,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                ImageUrl = values.ProductImageUrl,
                Quantity = 1
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        [Route("ShoppingCardUpdate/{productId}/{quantity}")]
        public async Task<IActionResult> ShoppingCardUpdate(string productId, int quantity)
        {
            var values = await _productService.GetByIdProductAsync(productId);
            var items = new BasketItemDto
            {
                ProductId = values.ProductID,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                ImageUrl = values.ProductImageUrl,
                Quantity = quantity
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index"); ;
        }
        [Route("RemoveBasketItem/{productId}")]
        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItem(productId);
            return RedirectToAction("Index");
        }
    }
}
