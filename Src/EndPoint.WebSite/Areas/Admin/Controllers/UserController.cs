using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Theme_Seller.Application.Services.Users.Commands.EditUser.IEditUserService;
using Theme_Seller.Application.Services.Users.Commands.EditUser;
using Theme_Seller.Application.Services.Users.Commands.RegisterUser;
using Theme_Seller.Application.Services.Users.Commands.RemoveUser;
using Theme_Seller.Application.Services.Users.Queries.GetUsers;
using Theme_Seller.Domain.Entities.Users;

namespace EndPoint.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IEditUserService _editUserService;
        public UsersController(IGetUsersService getUsersService, IRegisterUserService registerUserService, IRemoveUserService removeUserService, IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _editUserService = editUserService;
        }
        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = serchkey,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(string Email, string UserName,string Name,string FamilyName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                Name = Name,
                FamilyName= FamilyName,
                UserName = UserName,
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string UserName)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                UserName = UserName,
                UserId = UserId,
            }));
        }

    }
}
