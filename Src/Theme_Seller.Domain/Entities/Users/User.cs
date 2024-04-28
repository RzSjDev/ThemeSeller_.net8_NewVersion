using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Theme_Seller.Domain.Entities.Common;

namespace Theme_Seller.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId{ get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public string Password { get; set; }
        
    }
}
