using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows.Input;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory, IProductService productService, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _commentService = commentService;
        }
        public IActionResult Index(string id)
        {
            ViewBag.Dr1 = "Anasayfa";
            ViewBag.Dr2 = "/Default/Index/";
            ViewBag.Dr3 = "Ürünler";
            ViewBag.Dr4 = "/ProductList/Index/";
            ViewBag.Dr5 = "Ürün Listesi";
            if (id != null)
            {
                ViewData["cId"] = id;
            }
            return View();
        }
        public async Task<IActionResult> ProductDetail(string id)
        {
            ViewBag.Dr1 = "Anasayfa";
            ViewBag.Dr2 = "/Default/Index/";
            ViewBag.Dr3 = "Ürünler";
            ViewBag.Dr4 = "/ProductList/Index/";

            if (id != null)
            {
                ViewData["pId"] = id;
                var product = await _productService.GetByIdProductAsync(id);
                ViewBag.Dr5 = product.ProductName;
                ViewBag.pDId = product.ProductID;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.CreatedDate = DateTime.Now;
            createCommentDto.ImageUrl = "yok";
            createCommentDto.Status = false;
            await _commentService.CreateCommentAsync(createCommentDto);
            //var client = _httpClientFactory.CreateClient();
            //var jsondata = JsonConvert.SerializeObject(createCommentDto);
            //StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("http://localhost:7123/api/Comments", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Default");
            //}
            return RedirectToAction("ProductDetail", "ProductList", new { id = createCommentDto.ProductId });
        }
    }
}
