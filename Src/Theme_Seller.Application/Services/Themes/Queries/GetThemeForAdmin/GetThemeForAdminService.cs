using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Theme_seller.Common;
using Theme_Seller.Application.Interfaces.Context;

namespace Theme_Seller.Application.Services.Themes.Queries.GetThemeForAdmin
{
    public class GetThemeForAdminService : IGetThemeForAdminService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetThemeForAdminService(IMapper mapper,IDataBaseContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResultDto<ThemeForAdminDto> Execute(int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var theme = _context.themes
                .Include(p => p.CategoryThemes)
                .ToPaged(Page, PageSize, out rowCount)
                .Select(p => _mapper.Map<ThemeForAdminList_Dto>(p)).ToList();

            return new ResultDto<ThemeForAdminDto>()
            {
                Data = new ThemeForAdminDto()
                {
                    themes = theme,
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
