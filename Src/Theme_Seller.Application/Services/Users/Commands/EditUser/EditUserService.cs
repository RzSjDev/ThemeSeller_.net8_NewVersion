using Theme_Seller.Application.Interfaces.Context;
using Theme_seller.Common;

namespace Theme_Seller.Application.Services.Users.Commands.EditUser
{
    public partial interface IEditUserService
    {
        public class EditUserService : IEditUserService
        {
            private readonly IDataBaseContext _context;

            public EditUserService(IDataBaseContext context)
            {
                _context = context;
            }
            public ResultDto Execute(RequestEdituserDto request)
            {
                var user = _context.Users.Find(request.UserId);
                if (user == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "کاربر یافت نشد"
                    };
                }

                user.UserName = request.UserName;
                _context.SaveChanges();

                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "ویرایش کاربر انجام شد"
                };

            }
        }
    }
}
