using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.SignalRServices.SignalRCommentServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _HeaderAdminLayoutCommentComponentPartial : ViewComponent
    {
        private readonly ISignalRCommentService _signalRCommentService;

        public _HeaderAdminLayoutCommentComponentPartial(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var comments = await _signalRCommentService.GetUnApprovedComments();
            return View(comments);
        }
    }
}
