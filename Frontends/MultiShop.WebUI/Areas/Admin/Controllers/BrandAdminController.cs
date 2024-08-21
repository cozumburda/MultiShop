using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/BrandAdmin")]
    public class BrandAdminController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandAdminController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Listesi";
            ViewBag.t = "Marka İşlemleri";

            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Listesi";
            ViewBag.t = "Marka İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index", "BrandAdmin", new { area = "Admin" });
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "BrandAdmin", new { area = "Admin" });
        }
        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Listesi";
            ViewBag.t = "Marka İşlemleri";
            var values = await _brandService.GetByIdBrandAsync(id);
            return View(values);
        }
        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index", "BrandAdmin", new { area = "Admin" });
        }
    }
}
