using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("ProductDetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("ProductDetails/DeleteProductDetail/" + id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("ProductDetails");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("ProductDetails");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
            return values;
        }

        public async Task<UpdateProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("ProductDetails/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return value;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("ProductDetails", updateProductDetailDto);
        }

        public async Task<UpdateProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync("ProductDetails/GetProductDetailByProductId/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("ProductDetails");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
            return values;
        }
    }
}
