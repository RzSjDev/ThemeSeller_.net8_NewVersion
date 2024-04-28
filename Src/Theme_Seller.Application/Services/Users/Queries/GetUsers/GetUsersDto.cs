using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme_Seller.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
