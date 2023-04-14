using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using System.ComponentModel.DataAnnotations;  
  
namespace BlogMgmt.Models 
{  
    public class AccountModel  
    {  
        
        public string EmailId { get; set; }  
                  
        public string Password { get; set; }  
    }  
}  