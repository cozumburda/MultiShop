namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public interface ICommentStatisticService
    {
        Task<int> GetCommentsCount();
        Task<int> GetActiveCommentsCount();
        Task<int> GetPassiveCommentsCount();
    }
}
