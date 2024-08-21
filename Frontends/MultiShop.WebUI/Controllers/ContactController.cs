using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Dr1 = "Anasayfa";
            ViewBag.Dr2 = "/Default/Index/";
            ViewBag.Dr3 = "İletişim";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.SendDate = DateTime.Now;
            createContactDto.IsRead = false;
            if (ModelState.IsValid)
            {
                await _contactService.CreateContactAsync(createContactDto);
                TempData["contactInfo"] = "Mesajınız Gönderildi. En kısa sürede dönüş yapacağız. Mesajınız için Teşekkürler";
                TempData["contact1"] = createContactDto.NameSurname;
                TempData["contact2"] = createContactDto.Email;
                TempData["contact3"] = createContactDto.Subject;
                TempData["contact4"] = createContactDto.Message;
                TempData["contact5"] = createContactDto.SendDate.ToString("dd-MMM-yyyy HH:mm");
                return RedirectToAction("Index", "Contact");
            }
            return NoContent();

        }
    }
}
