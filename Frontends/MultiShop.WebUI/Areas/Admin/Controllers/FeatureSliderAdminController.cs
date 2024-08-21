using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSliderAdmin")]
    public class FeatureSliderAdminController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;
        public FeatureSliderAdminController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Öne Çıkan Görsel Listesi";
            ViewBag.t = "Öne Çıkan Görsel İşlemleri";

            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Öne Çıkan Görsel Ekle";
            ViewBag.t = "Öne Çıkan Görsel İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = false;
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);

            return RedirectToAction("Index", "FeatureSliderAdmin", new { area = "Admin" });
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);

            return RedirectToAction("Index", "FeatureSliderAdmin", new { area = "Admin" });
        }
        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Öne Çıkan Görsel Güncelleme";
            ViewBag.t = "Öne Çıkan Görsel İşlemleri";

            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);

            return View(values);
        }
        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);

            return RedirectToAction("Index", "FeatureSliderAdmin", new { area = "Admin" });
        }
        [Route("ChangeFeatureSliderStatusToFalse/{id}")]
        
        public async Task<IActionResult> ChangeFeatureSliderStatusToFalse(string id)
        {
            await _featureSliderService.FeatureSliderChangeToFalse(id);

            return RedirectToAction("Index", "FeatureSliderAdmin", new { area = "Admin" });
        }
        [Route("ChangeFeatureSliderStatusToTrue/{id}")]
        
        public async Task<IActionResult> ChangeFeatureSliderStatusToTrue(string id)
        {
            await _featureSliderService.FeatureSliderChangeToTrue(id);

            return RedirectToAction("Index", "FeatureSliderAdmin", new { area = "Admin" });
        }
    }
}
