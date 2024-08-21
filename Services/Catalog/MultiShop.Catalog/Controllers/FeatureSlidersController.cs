using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService FeatureSliderService)
        {
            _featureSliderService = FeatureSliderService;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Öne Çıkan Görsel Başarıyla Eklendi");
        }
        [HttpDelete("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öne Çıkan Görsel Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne Çıkan Görsel Başarıyla Güncellendi");
        }

        [HttpGet("ChangeFeatureSilderStatusToFalse/{id}")]
        public async Task<IActionResult> ChangeFeatureSilderStatusToFalse(string id)
        {
            await _featureSliderService.FeatureSliderChangeToFalse(id);
            return Ok("Durum False Yapıldı");
        }
        [HttpGet("ChangeFeatureSilderStatusToTrue/{id}")]
        public async Task<IActionResult> ChangeFeatureSilderStatusToTrue(string id)
        {
            await _featureSliderService.FeatureSliderChangeToTrue(id);
            return Ok("Durum True Yapıldı");
        }
    }
}
