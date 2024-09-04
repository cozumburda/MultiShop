
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetNonReadedMessageCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GetNonReadedMessageCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsondata);
            return values;
        }

        public async Task<int> GetReadedMessageCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GetReadedMessageCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsondata);
            return values;
        }

        public async Task<int> GetTotalMessageCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GetTotalMessageCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsondata);
            return values;
        }
    }
}
