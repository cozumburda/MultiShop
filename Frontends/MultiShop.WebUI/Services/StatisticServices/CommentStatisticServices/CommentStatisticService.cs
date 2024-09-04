using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetActiveCommentsCount()
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetActiveCommentCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsondata);
            return values;
        }

        public async Task<int> GetCommentsCount()
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetCommentCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsondata);
            return values;
        }

        public async Task<int> GetPassiveCommentsCount()
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetPassiveCommentCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsondata);
            return values;
        }
    }
}
