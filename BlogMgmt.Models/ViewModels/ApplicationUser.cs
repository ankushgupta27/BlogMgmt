using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
// using Microsoft.EntityFrameworkCore;  
using BlogMgmt.Models;
  
namespace BlogMgmt.Models  
{  
    public class ApplicationUser : BlogDbContxt  
    {
        public readonly object Countries;

        public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)  
        {  
  
        }  
        public ISet<CountryModel> country { get; set; }  
        
    }

    public class DbContextOptions<T>
    {
    }

    public class BlogDbContxt
    {
        public BlogDbContxt(DbContextOptions<ApplicationUser> options)
        {
        }
    }
}  