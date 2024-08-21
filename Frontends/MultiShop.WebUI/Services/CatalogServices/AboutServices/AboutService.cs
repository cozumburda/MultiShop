using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService:IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("Abouts", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("Abouts/DeleteAbout/" + id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("Abouts");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Abouts/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("Abouts", updateAboutDto);
        }
    }
}
