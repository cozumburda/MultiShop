
using System.Net.Http;

namespace MultiShop.SignalRRealTimeApi.Services
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SignalRMessageService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetTotalMessageCount()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7078/api/UserMessageStatistics");
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
