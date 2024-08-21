using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("Categories/DeleteCategory/" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("categories");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {            
            var responseMessage = await _httpClient.GetAsync("categories/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsByCategoryIdAsync(string CategoryId)
        {

            var responseMessage = await _httpClient.GetAsync("Products/GetProductsByCategoryId/" + CategoryId);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }
    }
}
