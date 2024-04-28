using Microsoft.AspNetCore.Mvc;
using Theme_Seller.Application.Services.Themes.FacadPattern;

namespace EndPoint.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {

        private readonly IFacadTheme _facadTheme;

        public CategoriesController(IFacadTheme facadTheme)
        {
            _facadTheme = facadTheme;
        }


        public IActionResult Index()
        {
            return View(_facadTheme.GetAllCategoriesService.Execute().Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(string Name)
        {
            var result = _facadTheme.AddNewCategoryService.Execute(Name);
            return Json(result);
        }
    }
}
