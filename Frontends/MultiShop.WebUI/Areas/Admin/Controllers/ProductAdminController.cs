using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductAdmin")]
    public class ProductAdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductAdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.t = "Ürün İşlemleri";

            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Ekle";
            ViewBag.t = "Ürün İşlemleri";
            var categories = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in categories
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            categoryValues.Add(new SelectListItem { Value = "", Text = "--Seçiniz--", Selected = true });
            ViewBag.categoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);

            return RedirectToAction("ProductListWithCategory", "ProductAdmin", new { area = "Admin" });
        }
        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme";
            ViewBag.t = "Ürün İşlemleri";
            var product = await _productService.GetByIdProductAsync(id);

            var categories = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in categories
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            categoryValues.Add(new SelectListItem { Value = "", Text = "--Seçiniz--", Selected = true });
            ViewBag.CategoryValues = categoryValues;

            return View(product);
        }
        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);

            return RedirectToAction("ProductListWithCategory", "ProductAdmin", new { area = "Admin" });            
        }
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);

            return RedirectToAction("ProductListWithCategory", "ProductAdmin", new { area = "Admin" });
        }
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.t = "Ürün İşlemleri";

            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }

        //void ProductViewBagList()
        //{
        //    ViewBag.v1 = "Anasayfa";
        //    ViewBag.v2 = "Kategoriler";
        //    ViewBag.v3 = "Kategori Listesi";
        //    ViewBag.t = "Kategori İşlemleri";
        //}
    }
}
