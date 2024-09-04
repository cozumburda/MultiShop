using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<long> GetBrandCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetBrandCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<long>(jsondata);
            return value;
        }

        public async Task<long> GetCategoryCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetCategoryCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<long>(jsondata);
            return value;
        }

        public async Task<string> GetMaxProductPrice()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMaxProductPrice");
            var value = await responseMessage.Content.ReadAsStringAsync(); 
            //var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //var value = JsonConvert.DeserializeObject<string>(jsondata);
            return value;
        }

        public async Task<string> GetMinProductPrice()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMinProductPrice");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //var value = JsonConvert.DeserializeObject<string>(jsondata);
            return jsondata;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductAvgPrice");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<decimal>(jsondata);
            return value;
        }

        public async Task<long> GetProductCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<long>(jsondata);
            return value;
        }
    }
}
