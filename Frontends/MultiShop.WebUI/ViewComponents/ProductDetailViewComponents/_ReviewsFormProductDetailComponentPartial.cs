using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ReviewsFormProductDetailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CreateCommentDto? m = new CreateCommentDto();
            return View(m);
        }
    }
}
