using AutoMapper;
using Theme_seller.Common;
using Theme_Seller.Application.Interfaces.Context;
using Theme_Seller.Domain.Entities.Users;

namespace Theme_Seller.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;

        public RegisterUserService(IMapper mapper,IDataBaseContext context)
        {
            _context = context;
            _mapper = mapper;   
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                var passwordHasher = new PasswordHash();
                var hashedPassword = passwordHasher.HashPassword(request.Password);
                var user=_mapper.Map<User>(request);
                user.Password = hashedPassword;
                user.Role = Roles.Costomer;
                _context.Users.Add(user);

                _context.SaveChanges();

                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد",
                };
            }
            catch (Exception)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }
        }
    }
}
