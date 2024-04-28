using Theme_Seller.Domain.Entities.Users;

namespace Theme_Seller.Application.Services.Users.Commands.LoginUser
{
    public class ResultUserloginDto
    {
        public long UserId { get; set; }
        public Roles Roles { get; set; }
        public string UserName { get; set; }
    }
}
