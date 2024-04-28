using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Theme_Seller.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDto
    {
        [Required(ErrorMessage = "نام را وارد نمایید")]
        [MinLength(2)]
        [DisplayName("اسم")]
        public string Name { get; set; }
        [Required(ErrorMessage = "نام خانوادگی را وارد نمایید")]
        [MinLength(2)]
        [DisplayName("فامیلی")]
        public string FamilyName { get; set; }
        [Required(ErrorMessage = "نام کاربری را وارد نمایید")]
        [MinLength(3,ErrorMessage ="نام کاربری باید بیش از 3 کاراکتر باشد")]
        [MaxLength(15,ErrorMessage = "نام کاربری باید کمتر از 15 کاراکتر باشد")]
        [DisplayName("نام کاربری")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [EmailAddress]
        [DisplayName("ایمیل")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$",ErrorMessage = "ایمیل خودرا به درستی وارد نمایید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "رمز عبور را وارد نمایید")]
        [MinLength(8,ErrorMessage ="حداقل باید 8 کاراکتر وارد شود")]
        [MaxLength(12,ErrorMessage = "حداقل باید 12 کاراکتر وارد شود")]
        [DisplayName("رمز")]
        public string Password { get; set; }
        [Required(ErrorMessage = "تکرار رمز عبور را وارد نمایید")]
        [Compare("Password",ErrorMessage ="رمز وارد شده برابر نمیباشد")]
        [DisplayName("تکرار رمز")]
        public string RePasword { get; set; }
    }
}
