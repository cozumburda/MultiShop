using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Yorum Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum Başarıyla Güncellendi");
        }
        [HttpDelete("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.UserComments.Find(id);
            _context.UserComments.Remove(comment);
            _context.SaveChanges();
            return Ok("Yorum Başarıyla Silindi");
        }
        [HttpGet("GetComment/{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _context.UserComments.Find(id);
            return Ok(value);
        }
        [HttpGet("ChangeStatusComment/{id}")]
        public IActionResult ChangeStatusComment(int id)
        {
            var value = _context.UserComments.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else if (value.Status == false)
            {
                value.Status = true;
            }
            _context.UserComments.Update(value);
            _context.SaveChanges();
            return Ok("Yorum Durumu Başarıyla Güncellendi");
        }
        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _context.UserComments.Where(x => x.ProductId == id);
            return Ok(value);
        }
        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            int activeCommentCount = _context.UserComments.Where(x => x.Status == true).Count();
            return Ok(activeCommentCount);
        }
        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            int passiveCommentCount = _context.UserComments.Where(x => x.Status == false).Count();
            return Ok(passiveCommentCount);
        }
        [HttpGet("GetCommentCount")]
        public IActionResult GetCommentCount()
        {
            int commentCount = _context.UserComments.Count();
            return Ok(commentCount);
        }
        [HttpGet("GetUnApprovedComments")]
        public IActionResult GetUnApprovedComments()
        {
            var values = _context.UserComments.Where(x => x.Status == false).ToList();
            return Ok(values);
        }
    }
}
