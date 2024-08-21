using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("FeatureSliders", createFeatureSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("FeatureSliders/DeleteFeatureSlider/" + id);
        }

        public async Task FeatureSliderChangeToFalse(string id)
        {
            await _httpClient.GetAsync("FeatureSliders/ChangeFeatureSilderStatusToFalse/" + id);
        }

        public async Task FeatureSliderChangeToTrue(string id)
        {
            await _httpClient.GetAsync("FeatureSliders/ChangeFeatureSilderStatusToTrue/" + id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("FeatureSliders");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("FeatureSliders/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("FeatureSliders", updateFeatureSliderDto);
        }
    }
}
