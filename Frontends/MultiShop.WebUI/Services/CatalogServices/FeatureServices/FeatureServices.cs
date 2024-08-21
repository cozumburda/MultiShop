using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureServices : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("Features", createFeatureDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("Features/DeleteFeature/" + id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("Features");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Features/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("Features", updateFeatureDto);
        }
    }
}
