using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_seller.Common;

namespace Theme_Seller.Application.Services.Themes.Queries.GetThemeForSite
{
    public interface IGetThemeForSiteService
    {
        ResultDto<ResultThemeForSiteDto> Execute(int Page);

    }
}
