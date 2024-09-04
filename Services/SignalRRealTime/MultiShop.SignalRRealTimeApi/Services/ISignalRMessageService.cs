namespace MultiShop.SignalRRealTimeApi.Services
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCount();       
    }
}
