using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("Comments", createCommentDto);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _httpClient.DeleteAsync("Comments/DeleteComment/" + id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("Comments");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("Comments");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetComment/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateCommentDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCommentDto>();
            return value;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("Comments", updateCommentDto);
        }

        public async Task<List<ResultCommentDto>> GetByProductIdCommentAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync("Comments/CommentListByProductId/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("Comments");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }

        public async Task ChangeStatusCommentAsync(int id)
        {
            await _httpClient.GetAsync("Comments/ChangeStatusComment/" + id);
        }
    }
}
