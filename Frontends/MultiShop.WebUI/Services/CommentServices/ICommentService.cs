using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(int id);
        Task ChangeStatusCommentAsync(int id);
        Task<UpdateCommentDto> GetByIdCommentAsync(int id);
        Task<List<ResultCommentDto>> GetByProductIdCommentAsync(string id);
    }
}
