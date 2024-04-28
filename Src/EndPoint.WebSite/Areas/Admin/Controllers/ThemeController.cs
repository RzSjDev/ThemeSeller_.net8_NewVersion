using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Theme_Seller.Application.Services.Themes.Commands.AddNewTheme;
using Theme_Seller.Application.Services.Themes.FacadPattern;

namespace EndPoint.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThemeController : Controller
    { 
        private readonly IFacadTheme _facadTheme;

        public ThemeController(IFacadTheme facadTheme)
        {
            _facadTheme = facadTheme;
        }
        public IActionResult Index(int Page = 1, int PageSize = 20)
        {
            return View(_facadTheme.GetThemeForAdminService.Execute(Page, PageSize).Data);
        }

        public IActionResult Detail(long Id)
        {
            return View(_facadTheme.GetThemeDetailForAdminService.Execute(Id).Data);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_facadTheme.GetAllCategoriesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewThemeDto request, List<AddNewTheme_Features> Features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = Features;
            return Json(_facadTheme.AddNewThemeService.Execute(request));
        }
    }

}
