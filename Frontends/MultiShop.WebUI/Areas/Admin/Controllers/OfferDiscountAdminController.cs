using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscountAdmin")]
    public class OfferDiscountAdminController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;
        public OfferDiscountAdminController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklifi Listesi";
            ViewBag.t = "İndirim Teklifi İşlemleri";

            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklifi Ekle";
            ViewBag.t = "İndirim Teklifi İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscountAdmin", new { area = "Admin" });

        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscountAdmin", new { area = "Admin" });

        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklifi Güncelleme";
            ViewBag.t = "İndirim Teklifi İşlemleri";
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);

        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscountAdmin", new { area = "Admin" });

        }
    }
}
