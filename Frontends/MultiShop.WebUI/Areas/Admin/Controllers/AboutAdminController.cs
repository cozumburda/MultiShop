using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AboutAdmin")]
    public class AboutAdminController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutAdminController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Listesi";
            ViewBag.t = "Hakkımızda İşlemleri";

            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Listesi";
            ViewBag.t = "Hakkımızda İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index", "AboutAdmin", new { area = "Admin" });
        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "AboutAdmin", new { area = "Admin" });
        }
        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Listesi";
            ViewBag.t = "Hakkımızda İşlemleri";
            var values = await _aboutService.GetByIdAboutAsync(id);
            return View(values);
        }
        [Route("UpdateAbout/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index", "AboutAdmin", new { area = "Admin" });
        }
    }
}
