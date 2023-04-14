using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogMgmt.web.Models;
using BlogMgmt.Business;

namespace BlogMgmt.web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBlogBusiness _iBlogBusiness;


    public HomeController(ILogger<HomeController> logger,IBlogBusiness iBlogBusiness)
    {
        _logger = logger;
        _iBlogBusiness= iBlogBusiness;
    }

    public IActionResult Index()
    {
        _iBlogBusiness.GetBlogs();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
