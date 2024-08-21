using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ReviewsProductDetailComponentPartial : ViewComponent
    {        
        private readonly ICommentService _commentService;
        public _ReviewsProductDetailComponentPartial(IHttpClientFactory httpClientFactory, ICommentService commentService)
        {            
            _commentService = commentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _commentService.GetByProductIdCommentAsync(id);           
            return View(values);
        }
    }
}
