using Microsoft.EntityFrameworkCore;
using Theme_seller.Common;
using Theme_Seller.Application.Interfaces.Context;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Theme_Seller.Application.Services.Themes.Queries.GetProductDetailForAdmin
{
    public class GetThemeDetailForAdminService : IGetThemeDetailForAdminService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;

        public GetThemeDetailForAdminService(IMapper mapper,IDataBaseContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResultDto<ThemeDetailForAdmindto> Execute(long Id)
        {
            var theme = _context.themes
                .Include(p => p.CategoryThemes)
                .Include(p => p.ThemeFeatures)
                .Include(p => p.ThemeImages)
            .Where(p => p.Id == Id)
                .FirstOrDefault();
            var Data = _mapper.Map<ThemeDetailForAdmindto>(theme);
            Data.Features= theme.ThemeFeatures.ToList().Select(p =>_mapper.Map<ThemeDetailFeatureDto>(p)).ToList();
            Data.Images = theme.ThemeImages.ToList().Select(p => _mapper.Map<ThemeDetailImagesDto>(p)).ToList();
            
            return new ResultDto<ThemeDetailForAdmindto>()
            {
                Data = Data,
                IsSuccess = true,
                Message = "",
            };
        }
    }

}
