using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{    
    [Area("Admin")]
    [Route("Admin/ProductAdminImage")]
    public class ProductAdminImageController : Controller
    {
        private readonly IProductImageService _productImageService;
        private readonly IProductService _productService;

        public ProductAdminImageController(IProductImageService productImageService, IProductService productService)
        {
            _productImageService = productImageService;
            _productService = productService;
        }

        [Route("ProductImageDetail/{id}")]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görselleri";
            ViewBag.t = "Ürün Görsel İşlemleri";

            var values2 = await _productService.GetByIdProductAsync(id);

            ViewBag.pName = values2.ProductName;
            ViewBag.pId = values2.ProductID;

            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return View(values);
        }

        [Route("CreateProductImage/{id}")]
        [HttpGet]
        public async Task<IActionResult> CreateProductImage(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görselleri";
            ViewBag.t = "Ürün Görseli Ekleme Sayfası";

            var values2 = await _productService.GetByIdProductAsync(id);

            ViewBag.pName = values2.ProductName;
            ViewBag.pId = values2.ProductID;

            return View();
        }
        [Route("CreateProductImage")]
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return RedirectToAction("ProductImageDetail", "ProductAdminImage", new { area = "Admin", id = createProductImageDto.ProductID });
        }
        [Route("UpdateProductImage/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görselleri";
            ViewBag.t = "Ürün Görseli Güncelleme Sayfası";

            var values2 = await _productImageService.GetByIdProductImageAsync(id);

            var pID = values2.ProductID;
            var value = await _productService.GetByIdProductAsync(pID);
            ViewBag.pName = value.ProductName;

            return View(values2);
        }
        [Route("UpdateProductImage")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return RedirectToAction("ProductImageDetail", "ProductAdminImage", new { area = "Admin", id = updateProductImageDto.ProductID });
        }
        [Route("DeleteProductImage/{id}")]
        [Route("DeleteProductImage")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var pId = "";
            var value2 = await _productImageService.GetByIdProductImageAsync(id);
            pId = value2.ProductID;

            await _productImageService.DeleteProductImageAsync(id);
            return RedirectToAction("ProductImageDetail", "ProductAdminImage", new { area = "Admin", id = pId });
        }
    }
}
