using MultiShop.DtoLayer.SignalRDtos;

namespace MultiShop.WebUI.Services.SignalRServices.SignalRCommentServices
{
    public interface ISignalRCommentService
    {
        Task<List<ResultUnApprovedComments>> GetUnApprovedComments();
    }
}
