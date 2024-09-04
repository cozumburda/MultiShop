namespace MultiShop.SignalRRealTimeApi.Services
{
    public interface ISignalRCommentService
    {
        Task<int> GetCommentsCount();
    }
}
