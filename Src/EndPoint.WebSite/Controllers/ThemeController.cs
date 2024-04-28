using Microsoft.AspNetCore.Mvc;
using Theme_Seller.Application.Services.Themes.FacadPattern;

namespace EndPoint.WebSite.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IFacadTheme _facadTheme;

        public ThemeController(IFacadTheme facadTheme)
        {
            _facadTheme = facadTheme;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_facadTheme.GetThemeForSiteService.Execute(page).Data);
        }


        public IActionResult Detail(long Id)
        {
            return View(_facadTheme.GetThemeDetailForSiteService.Execute(Id).Data);
        }
    }
}
