using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRMessageService _signalRMessageService;
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {
            _signalRCommentService = signalRCommentService;
            _signalRMessageService = signalRMessageService;
        }
        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.GetCommentsCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
            
            var getTotalMessageCount = await _signalRMessageService.GetTotalMessageCount();
            await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
        }
    }
}
