using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.EntityFrameworkCore;  
using BlogMgmt.Models;  
  
  
namespace BlogMgmt.Controllers  
{  
    public class DropdownController : Controller  
    {  
        private readonly ApplicationUser _auc;  
  
        public DropdownController(ApplicationUser auc)  
        {  
            _auc = auc;  
        }  
        // public IActionResult Index()  
        // {  
        //     List<Country> cl = new List<Country>();  
        //     cl = (from c in _auc.country select c).ToList();  
        //     cl.Insert(0, new Country { Id= 0, Name = "--Select Country Name--" });  
        //     ViewBag.message = cl;  
        //     return View();  
        // }  
    }  
}  