using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_Seller.Application.Services.Themes.Commands.AddNewCategory;
using Theme_Seller.Application.Services.Themes.Commands.AddNewTheme;
using Theme_Seller.Application.Services.Themes.Queries.GetAllCategoreis;
using Theme_Seller.Application.Services.Themes.Queries.GetProductDetailForAdmin;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeDetailForSite;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeForAdmin;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeForSite;

namespace Theme_Seller.Application.Services.Themes.FacadPattern
{
    public interface IFacadTheme
    {
        IAddNewCategoryService AddNewCategoryService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IAddNewThemeService AddNewThemeService { get; }
        IGetThemeForAdminService GetThemeForAdminService { get; }
        IGetThemeDetailForAdminService GetThemeDetailForAdminService { get; }
        IGetThemeForSiteService GetThemeForSiteService { get; }
        IGetThemeDetailForSiteService GetThemeDetailForSiteService { get; }
    }
}
