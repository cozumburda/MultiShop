using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{    
    [Area("Admin")]
    [Route("Admin/ProductAdminDetail")]
    public class ProductAdminDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductAdminDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [Route("UpdateProductDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Açıklama ve Bilgi Güncelleme Sayfası";
            ViewBag.t = "Ürün İşlemleri";
            ViewBag.pErrorId = id;

            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);

            ViewBag.pUId = id;
            return View(values);
        }
        [Route("UpdateProductDetail")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto, string pid)
        {
            if (ModelState.IsValid)
            {
                await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
                return RedirectToAction("ProductListWithCategory", "ProductAdmin", new { area = "Admin" });
            }
            TempData["detailUpdateError"] = "Detay Mevcut Değil, Lütfen Ürün Yeni Detay Ekleme Sayfasından Detay Kaydediniz (Bu Sayfa)";
            return RedirectToAction("CreateProductDetail", "ProductAdminDetail", new { area = "Admin", id = pid });
        }
        [HttpGet]
        [Route("CreateProductDetail/{id}")]
        public IActionResult CreateProductDetail(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Detayı Ekleme Sayfası";
            ViewBag.t = "Ürün İşlemleri";
            ViewBag.pId = id;
            return View();
        }
        [HttpPost]
        [Route("CreateProductDetail")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDto)
        {
            var values2 = await _productDetailService.GetByProductIdProductDetailAsync(createProductDto.ProductID);

            if (values2 != null)
            {
                TempData["detailError"] = "Detay Mevcut, Yönlendirildiğiniz Güncelleme sayfasından değişiklik yapabilirsiniz ! (Bu Sayfa)";
                return RedirectToAction("UpdateProductDetail", "ProductAdminDetail", new { area = "Admin", id = createProductDto.ProductID });
            }
            else
            {
                await _productDetailService.CreateProductDetailAsync(createProductDto);
                return RedirectToAction("ProductListWithCategory", "ProductAdmin", new { area = "Admin" });
            }
        }
    }
}
