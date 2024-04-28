using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Theme_seller.Common;
using Theme_Seller.Application.Interfaces.Context;

namespace Theme_Seller.Application.Services.Themes.Queries.GetThemeForSite
{
    public class GetThemeForSiteService : IGetThemeForSiteService
    {

        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetThemeForSiteService(IMapper mapper,IDataBaseContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<ResultThemeForSiteDto> Execute(int Page)
        {
            int totalRow = 0;
            var themes = _context.themes
                .Include(p => p.ThemeImages)
                .ToPaged(Page, 5, out totalRow);

            Random rd = new Random();

            return new ResultDto<ResultThemeForSiteDto>
            {
                Data = new ResultThemeForSiteDto
                {
                    TotalRow = totalRow,
                    Themes = themes.Select(p => new ThemeForSiteDto
                    {
                        Id = p.Id,
                        Star = rd.Next(1, 5),
                        Title = p.Name,
                        ImageSrc = p.ThemeImages.FirstOrDefault().Src,
                        Price = p.Price
                    }).ToList(),
                    
                },
                IsSuccess = true,
            };
        }
    }


}
