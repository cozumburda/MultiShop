using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CategoryAdmin")]
    public class CategoryAdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryAdminController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        void CategoryViewBagList()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.t = "Kategori İşlemleri";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            CategoryViewBagList();

            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            CategoryViewBagList();
            return View();
        }
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            var url = "/Admin/CategoryAdmin/Index/";
            return Redirect(url);
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            var url = "/Admin/CategoryAdmin/Index/";
            return Redirect(url);

        }
        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryViewBagList();
            var value = await _categoryService.GetByIdCategoryAsync(id);
            //UpdateCategoryDto model = new UpdateCategoryDto()
            //{
            //    CategoryID = id,
            //    CategoryName = value.CategoryName,
            //    ImageUrl = value.ImageUrl
            //};

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:7070/api/Categories/" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsondata);
            //    return View(values);
            //}
            return View(value);
        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsondata = JsonConvert.SerializeObject(updateCategoryDto);
            //StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:7070/api/Categories", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var url = "/Admin/CategoryAdmin/Index/";
            //    return Redirect(url);
            //}
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            var url = "/Admin/CategoryAdmin/Index/";
            return Redirect(url);

        }
        [Route("GetProductsByCategoryId/{id}")]
        public async Task<IActionResult> GetProductsByCategoryId(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";

            var value2 = await _categoryService.GetByIdCategoryAsync(id);

            var value = await _categoryService.GetProductsByCategoryIdAsync(id);

            ViewBag.t = value.Count > 0 ? value2.CategoryName + " " + "Kategorisindeki Ürünler" : value2.CategoryName + " " + "Kategorisinde Henüz Ürün Yok";

            return View(value);
        }
    }
}
