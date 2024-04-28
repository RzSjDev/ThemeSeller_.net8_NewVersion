using Theme_Seller.Application.Interfaces.Context;
using Theme_seller.Common;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Theme_Seller.Application.Services.Themes.Queries.GetThemeDetailForSite
{
    public class GetThemeDetailForSiteService : IGetThemeDetailForSiteService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetThemeDetailForSiteService(IMapper mapper,IDataBaseContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<ThemeDetailForSiteDto> Execute(long Id)
        {
            var theme = _context.themes
                .Include(p => p.CategoryThemes)
                .Include(p => p.ThemeImages)
                .Include(p => p.ThemeFeatures)
                .Where(p => p.Id == Id).FirstOrDefault();

            if (theme == null)
            {
                throw new Exception("Theme Not Found.....");
            }
            var Data=_mapper.Map<ThemeDetailForSiteDto>(theme);
            Data.Features = theme.ThemeFeatures.Select(p => _mapper.Map<ThemeDetailForSite_FeaturesDto>(p)).ToList();
            return new ResultDto<ThemeDetailForSiteDto>()
            {
                Data = Data,
                IsSuccess = true
            };

        }
    }




}
