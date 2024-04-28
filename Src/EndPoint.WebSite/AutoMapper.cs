using AutoMapper;
using Theme_Seller.Application.Services.Themes.Commands.AddNewTheme;
using Theme_Seller.Application.Services.Themes.Queries.GetAllCategoreis;
using Theme_Seller.Application.Services.Themes.Queries.GetProductDetailForAdmin;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeDetailForSite;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeForAdmin;
using Theme_Seller.Application.Services.Users.Commands.RegisterUser;
using Theme_Seller.Application.Services.Users.Queries.GetUsers;
using Theme_Seller.Domain.Entities.Themes;
using Theme_Seller.Domain.Entities.Users;

namespace EndPoint.WebSite
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<RequestAddNewThemeDto,Theme>();
            CreateMap<ThemeCategories, AllCategoriesDto>();
            CreateMap<ThemeFeatures, ThemeDetailFeatureDto>();
            CreateMap<ThemeImages, ThemeDetailImagesDto>();
            CreateMap<Theme, ThemeDetailForAdmindto>();
            CreateMap<Theme, ThemeDetailForSiteDto>();
            CreateMap<Theme, ThemeDetailForSite_FeaturesDto>();
            CreateMap<Theme, ThemeForAdminList_Dto>();
            CreateMap<User, GetUsersDto>();
            CreateMap<RequestRegisterUserDto, User>();
        }
    }
}
