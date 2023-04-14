// namespace BlogMgmt.Models.ViewModels
// {
//     public class Country
//     {
        
//     }
// }
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using System.ComponentModel.DataAnnotations;  
  
namespace BlogMgmt.Models 
{  
    public class CountryModel  
    {  
        [Key]  
        public int Id { get; set; }  
                  
        public string Name { get; set; }  
    }  


}  
