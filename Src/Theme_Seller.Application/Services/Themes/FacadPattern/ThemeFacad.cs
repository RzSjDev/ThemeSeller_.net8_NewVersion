using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_Seller.Application.Interfaces.Context;
using Theme_Seller.Application.Services.Themes.Commands.AddNewCategory;
using Theme_Seller.Application.Services.Themes.Commands.AddNewTheme;
using Theme_Seller.Application.Services.Themes.Queries.GetAllCategoreis;
using Theme_Seller.Application.Services.Themes.Queries.GetProductDetailForAdmin;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeDetailForSite;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeForAdmin;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeForSite;

namespace Theme_Seller.Application.Services.Themes.FacadPattern
{
    public class ThemeFacad:IFacadTheme
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;
        public ThemeFacad(IMapper mapper,IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
            _mapper = mapper;
        }

        private IAddNewCategoryService _addNewCategory;
        public IAddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }


        private IAddNewThemeService _addNewThemeService;
        public IAddNewThemeService AddNewThemeService
        {
            get
            {
                return _addNewThemeService = _addNewThemeService ?? new AddNewThemeService(_mapper,_context, _environment);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_mapper,_context);
            }
        }

        private IGetThemeForAdminService _getThemeForAdminService;
        public IGetThemeForAdminService GetThemeForAdminService
        {
            get
            {
                return _getThemeForAdminService = _getThemeForAdminService ?? new GetThemeForAdminService(_mapper,_context);
            }
        }


        private IGetThemeDetailForAdminService _getThemeDetailForAdminService;
        public IGetThemeDetailForAdminService GetThemeDetailForAdminService
        {
            get
            {
                return _getThemeDetailForAdminService = _getThemeDetailForAdminService ?? new GetThemeDetailForAdminService(_mapper, _context);
            }
        }


        private IGetThemeForSiteService _getThemeForSiteService;
        public IGetThemeForSiteService GetThemeForSiteService
        {
            get
            {
                return _getThemeForSiteService = _getThemeForSiteService ?? new GetThemeForSiteService(_mapper, _context);
            }
        }


        private IGetThemeDetailForSiteService _getThemeDetailForSiteService;
        public IGetThemeDetailForSiteService GetThemeDetailForSiteService
        {
            get
            {
                return _getThemeDetailForSiteService = _getThemeDetailForSiteService ?? new GetThemeDetailForSiteService(_mapper, _context);
            }
        }
    }
}
