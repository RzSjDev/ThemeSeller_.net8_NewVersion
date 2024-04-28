using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_seller.Common;
using Theme_Seller.Domain.Entities.Themes;

namespace Theme_Seller.Application.Services.Themes.Queries.GetProductDetailForAdmin
{
    public interface IGetThemeDetailForAdminService
    {
        ResultDto<ThemeDetailForAdmindto> Execute(long Id);

    }

}
