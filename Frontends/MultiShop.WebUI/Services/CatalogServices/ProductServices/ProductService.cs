using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("Products", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("Products/DeleteProduct/" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Products");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Products/GetProductById?id=" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }        

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Products/ProductListWithCategory");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("Products", updateProductDto);
        }
    }
}
