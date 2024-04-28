using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_Seller.Domain.Entities.Common;

namespace Theme_Seller.Domain.Entities.Themes
{
    public class ThemeFeatures:BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public long ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
        
    }
}
