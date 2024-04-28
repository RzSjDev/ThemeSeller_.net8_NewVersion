using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_seller.Common;

namespace Theme_Seller.Application.Services.Themes.Queries.GetThemeForAdmin
{
    public interface IGetThemeForAdminService
    {
        ResultDto<ThemeForAdminDto> Execute(int Page = 1, int PageSize = 20);
    }
}
