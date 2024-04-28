using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_Seller.Domain.Entities.Common;

namespace Theme_Seller.Domain.Entities.Themes
{
    public class ThemeCategories:BaseEntity
    {
        [Key]
        public long CategoryId { get; set; }
        public string Name { get; set; }

    }
}
