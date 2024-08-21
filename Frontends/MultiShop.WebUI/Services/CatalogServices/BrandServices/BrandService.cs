using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService:IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("Brands", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("Brands/DeleteBrand/" + id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("Brands");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Brands/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateBrandDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("Brands", updateBrandDto);
        }
    }
}
