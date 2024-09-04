using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CargoAdmin")]
    public class CargoAdminController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoAdminController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [Route("CargoCompanyList")]
        public async Task<IActionResult> CargoCompanyList()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kargo Şirketleri";
            ViewBag.v3 = "Kargo Şirketleri Listesi";
            ViewBag.t = "Kargo Şirketi İşlemleri";
            var cargoCompanies = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return View(cargoCompanies);
        }
        [Route("CreateCargoCompany")]
        [HttpGet]
        public IActionResult CreateCargoCompany()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kargo Şirketleri";
            ViewBag.v3 = "Kargo Şirketi Ekle";
            ViewBag.t = "Kargo Şirketi Ekle";

            return View();
        }
        [Route("CreateCargoCompany")]
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("CargoCompanyList");
        }
        [Route("UpdateCargoCompany/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kargo Şirketleri";
            ViewBag.v3 = "Kargo Şirketi Güncelle";
            ViewBag.t = "Kargo Şirketi Güncelle";
            var cargoCompany = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(cargoCompany);
        }
        [Route("UpdateCargoCompany/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("CargoCompanyList");
        }
        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList");
        }
    }
}
