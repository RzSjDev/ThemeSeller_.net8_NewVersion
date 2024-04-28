using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_Seller.Domain.Entities.Common;

namespace Theme_Seller.Domain.Entities.Themes
{
    public class Theme:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Displayed { get; set; }
        public long CategoryId { get; set; }
        public virtual ThemeCategories CategoryThemes { get; set; }      
        public virtual ICollection<ThemeImages> ThemeImages { get; set; }
        public virtual ICollection<ThemeFeatures> ThemeFeatures { get; set; }
    }
}
