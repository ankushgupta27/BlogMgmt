using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogMgmt.Business;
using BlogMgmt.Data.Entities;
using BlogMgmt.Models;
using BlogMgmt.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
namespace BlogMgmt.Web.Controllers
{

    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public readonly IUserBusiness _iUserBusiness;
        public readonly IBlogBusiness _iBlogBusiness;

        // private object _iUserBussiness;

        public UserController(ILogger<UserController> logger, IUserBusiness iUserBusiness, IBlogBusiness iBlogBusiness)
        {
            _logger = logger;
            _iUserBusiness = iUserBusiness;
            _iBlogBusiness = iBlogBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult BlogList(string Sorting_Order, string Search_Data, int pg = 1)
        {
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            // ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";

         List<Blog> BlogDetail= _iBlogBusiness.GetBlogList(ViewBag.SortingName,Search_Data);
            const int pageSize = 3;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = BlogDetail.Count;
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = BlogDetail.Skip(recSkip).Take(pager.Pagesize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);


        }
        public IActionResult Register()
        {
            List<Country> cl = new List<Country>();
            // cl = (from c in _auc.country select c).ToList();
            cl = _iUserBusiness.GetCountryList();
            cl.Insert(0, new Country { Id = 0, Name = "--Select Country Name--" });
            ViewBag.message = cl;
            return View();
        }

        public IActionResult AddBlog(int id)
        {
            List<Category> cl = new List<Category>();
            // cl = (from c in _auc.country select c).ToList();
            cl = _iBlogBusiness.GetCategoryList();
            cl.Insert(0, new Category { Id = 0, Name = "--Select Category--" });
            ViewBag.message = cl;
            if (id > 0)
            {
                AddBlogModel blog = _iBlogBusiness.GetBlogById(id);
                return View(blog);
            }
            return View();
        }

        public IActionResult GetStates(int countryId)
        {
            List<State> cl = new List<State>();
            // cl = (from c in _auc.country select c).ToList();
            cl = _iUserBusiness.GetStateList(countryId);
            cl.Insert(0, new State { Id = 0, Name = "--Select State Name--" });
            ViewBag.message = cl;
            return Json(cl);
        }
        public IActionResult GetCities(int stateId)
        {
            List<City> cl = new List<City>();
            // cl = (from c in _auc.country select c).ToList();
            cl = _iUserBusiness.GetCityList(stateId);
            cl.Insert(0, new City { Id = 0, Name = "--Select City Name--" });
            ViewBag.message = cl;
            return Json(cl);
        }
        [HttpPost]
        public IActionResult AddUser(UserViewModel user)
        {
            
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _iUserBusiness.AddUser(user);
            return RedirectToAction(actionName: "LoginPage", controllerName: "User");
            // return View();
        }


        [HttpPost]
        public IActionResult Loginpage(UserLoginViewModel LoginModel)
        {
            var AccountModel = new UserViewModel();
            AccountModel.Email=LoginModel.Email;
            AccountModel.Password=LoginModel.Password;
            var userDetails = _iUserBusiness.Login(AccountModel);
            if (userDetails != null && BCrypt.Net.BCrypt.Verify(AccountModel.Password, userDetails.Password))
            {
                var claims = new Claim[] { new Claim(ClaimTypes.Email, userDetails.EmailId), new Claim(ClaimTypes.Role, userDetails.RoleId.ToString()), new Claim("UserId", userDetails.Id.ToString()) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                if (userDetails.RoleId == 4)
                {
                    return RedirectToAction("UserDetails", "User");
                }
                else if (userDetails.RoleId == 5 || userDetails.RoleId == 6)
                {

                    return RedirectToAction("BlogList", "User");
                }
                else
                {
                    ViewData["Errormsg"] = "Incorrect Email or Password";
                    return View("LoginPage");
                }
            }
            else
            {
                ViewData["Errormsg"] = "Incorrect Email or Password";
                return View("LoginPage");
            }
        }

        //  if(userDetails.RoleId==4){

        //     
        // }
        // else if(userDetails.RoleId==5 || userDetails.RoleId==6){

        //      return RedirectToAction("BlogList", "User");
        // }
        // else
        // {
        //     ViewData["Errormsg"] = "Incorrect Email or Password";
        //     return View("LoginPage");
        // }
        [HttpPost]
        public IActionResult AddBlogDetail(Blog blgDetail)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            blgDetail.CreatedBy = Convert.ToInt32(userId);
            _iBlogBusiness.AddBlogDetail(blgDetail);
            return RedirectToAction(actionName: "BlogList", controllerName: "User");
            // return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        [HttpGet]
        [Authorize(Roles = "4")]
        public IActionResult UserDetails()
        {
            var UserDetail = _iUserBusiness.GetUserList();
            return View(UserDetail);
        }
        public IActionResult DeleteCandidate(int Id)
        {
            using (var context = new BlogDBContext())
            {
                var candidateRecord = context.Users.FirstOrDefault(x => x.Id == Id); if (candidateRecord != null)
                {
                    context.Users.Remove(candidateRecord); context.SaveChanges();
                }
                return RedirectToAction(actionName: "UserDetails", controllerName: "User");
            }
        }
        [HttpGet]
        [Authorize(Roles = "4")]
        public IActionResult GetBlogDetail(int id)
        {
            AddBlogModel blog = _iBlogBusiness.GetBlogById(id);
            return RedirectToAction(actionName: "EditBLog", controllerName: "User", blog);
        }
        public IActionResult ChangeBlogDetail(EditBlogModel editBlogModel)
        {

            _iBlogBusiness.EditBlogDetail(editBlogModel);
            return RedirectToAction(actionName: "BlogList", controllerName: "User");
        }
        public IActionResult EditBlog()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("LoginPage");
        }
        public IActionResult DeleteBlog(int Id)
        {
            using (var context = new BlogDBContext())
            {
                var candidateRecord = context.Blogs.FirstOrDefault(x => x.Id == Id);
                if (candidateRecord != null)
                {
                    context.Blogs.Remove(candidateRecord); context.SaveChanges();
                }
                return RedirectToAction(actionName: "BlogList", controllerName: "User");
            }
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {
            if (_iUserBusiness.VerifyEmail(email) == true)
            {
                return Json($"Email {email} is already in use.");
            }
            return Json(true);
        }

        public IActionResult ViewBlog(int Id)
        {
            using (var context = new BlogDBContext())
            {
                var candidateList = context.Blogs.Include(x => x.Category).Include(x => x.UpdatedByNavigation).FirstOrDefault(x => x.Id == Id);
                // var candidateList = context.CandidateInformations.Find(Id);
                return View(candidateList);
            }

        }

    }
}
