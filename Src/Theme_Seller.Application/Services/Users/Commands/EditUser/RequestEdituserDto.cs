namespace Theme_Seller.Application.Services.Users.Commands.EditUser
{
    public partial interface IEditUserService
    {
        public class RequestEdituserDto
        {
            public long UserId { get; set; }
            public string UserName { get; set; }
        }
    }
}
