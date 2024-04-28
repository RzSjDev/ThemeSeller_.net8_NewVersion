using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Theme_seller.Presistance.Context;
using Theme_Seller.Application.Interfaces.Context;
using static Theme_Seller.Application.Services.Users.Commands.EditUser.IEditUserService;
using Theme_Seller.Application.Services.Users.Commands.EditUser;
using Theme_Seller.Application.Services.Users.Commands.LoginUser;
using Theme_Seller.Application.Services.Users.Commands.RegisterUser;
using Theme_Seller.Application.Services.Users.Commands.RemoveUser;
using Theme_Seller.Application.Services.Users.Queries.GetUsers;
using Theme_Seller.Application.Services.Themes.FacadPattern;
using Theme_Seller.Application.Services.Themes.Commands.AddNewCategory;
using Theme_Seller.Application.Services.Themes.Commands.AddNewTheme;
using Theme_Seller.Application.Services.Themes.Queries.GetAllCategoreis;
using Theme_Seller.Application.Services.Themes.Queries.GetProductDetailForAdmin;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeDetailForSite;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeForAdmin;
using Theme_Seller.Application.Services.Themes.Queries.GetThemeForSite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();

builder.Services.AddScoped<IAddNewCategoryService, AddNewCategoryService>();
builder.Services.AddScoped<IAddNewThemeService, AddNewThemeService>();
builder.Services.AddScoped<IGetAllCategoriesService, GetAllCategoriesService>();
builder.Services.AddScoped<IGetThemeDetailForAdminService, GetThemeDetailForAdminService>();
builder.Services.AddScoped<IGetThemeDetailForSiteService, GetThemeDetailForSiteService>();
builder.Services.AddScoped<IGetThemeForAdminService, GetThemeForAdminService>();
builder.Services.AddScoped<IGetThemeForSiteService, GetThemeForSiteService>();

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IFacadTheme, ThemeFacad>();



builder.Services.AddDbContext<DataBaseContext>(Option => Option.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapAreaControllerRoute(
      name: "areas",
      areaName:"Admin",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.Run();



