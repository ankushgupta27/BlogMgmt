using BlogMgmt.Business;
using BlogMgmt.Data.Entities;
using BlogMgmt.Models;
using BlogMgmt.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x=>x.LoginPath=new PathString("/Account/Index"));
builder.Services.AddScoped<IBlogBusiness,BlogBusiness>();
builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped<IUserBusiness,UserBuisness>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddControllersWithViews()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
// services.AddDbContext<ApplicationUser>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));  
builder.Services.AddDbContext<BlogDBContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("BlogManagmentDatabase")));
         
        
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=LoginPage}/{id?}");

app.Run();
