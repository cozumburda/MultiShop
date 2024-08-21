using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("ProductImages", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("ProductImages/DeleteProductImage/" + id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("ProductImages");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("ProductImages");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
            return values;
        }

        public async Task<UpdateProductImageDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("ProductImages/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return value;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("ProductImages", updateProductImageDto);
        }

        public async Task<List<UpdateProductImageDto>> GetByProductIdProductImageAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync("ProductImages/ProductImageListByProductId/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<UpdateProductImageDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("ProductImages");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
            return values;
        }
    }
}
