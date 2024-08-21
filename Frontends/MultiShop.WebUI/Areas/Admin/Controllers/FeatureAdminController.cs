using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureAdmin")]
    public class FeatureAdminController : Controller
    {
        private readonly IFeatureService _featureService;
        public FeatureAdminController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Listesi";
            ViewBag.t = "Öne Çıkan İşlemleri";

            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Ekle";
            ViewBag.t = "Öne Çıkan İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);

            return RedirectToAction("Index", "FeatureAdmin", new { area = "Admin" });
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);

            return RedirectToAction("Index", "FeatureAdmin", new { area = "Admin" });
        }
        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Güncelleme";
            ViewBag.t = "Öne Çıkan İşlemleri";

            var values = await _featureService.GetByIdFeatureAsync(id);

            return View(values);
        }
        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);

            return RedirectToAction("Index", "FeatureAdmin", new { area = "Admin" });
        }
    }
}
