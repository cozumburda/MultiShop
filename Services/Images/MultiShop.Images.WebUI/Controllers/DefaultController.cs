using Microsoft.AspNetCore.Mvc;
using MultiShop.Images.WebUI.DAL.Entities;
using MultiShop.Images.WebUI.Services;

namespace MultiShop.Images.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICloudStorageService _cloudStorageService;

        public DefaultController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ImageDrive imageDrive)
        {
            if (imageDrive.Photo != null)
            {
                imageDrive.SavedFileName = GenerateFileNameToSave(imageDrive.Photo.FileName);
                imageDrive.SavedUrl = await _cloudStorageService.UploadFileAsync(imageDrive.Photo, imageDrive.SavedFileName);
            }
            var url=GenerateSignedUrl(imageDrive);
            return RedirectToAction("Index", "Default");
        }
        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }

        private async Task GenerateSignedUrl(ImageDrive imageDrive)
        {
            // Get Signed URL only when Saved File Name is available.
            if (!string.IsNullOrWhiteSpace(imageDrive.SavedFileName))
            {
                imageDrive.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(imageDrive.SavedFileName);
            }
        }
    }
}
