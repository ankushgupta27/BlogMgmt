using BlogMgmt.Data.Entities;
using BlogMgmt.Models;
using BlogMgmt.Data;
using BlogMgmt.Models.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlogMgmt.Repository
{
    public class UserRepository : IUserRepository
    {
    
        public bool AddUser(UserViewModel user){
             using (var context = new BlogDBContext())
        {
            User users = new User();
            users.FullName = user.FullName;
            users.EmailId = user.Email;
            users.Password = user.Password;
            users.CityId = user.CityId;
            users.StateId = user.StateId;
            users.CountryId = user.CountryId;
            users.MobileNo = user.MobileNo;
            users.IsActive=true;
             users.IsEmailVerified = false;
            users.RoleId= (int)Convert.ToInt64(Common.Role.Blogger);
            users.CreatedBy = user.Id;
            users.CreatedOn = DateTime.Now;
            users.UpdatedBy = user.Id;
            users.UpdatedOn = DateTime.Now;
            
            
           
           
           
            context.Add(users);
            context.SaveChanges();
        }
        return true;
        }
        public List<Country> GetCountryList()
        {
             using (var context = new BlogDBContext()){

              var countrylist = context.Countries.ToList(); 
              return countrylist;
             }
        }
         public List<State> GetStateList(int countryId)
        {
             using (var context = new BlogDBContext()){

              var statelist = context.States.Where(x=>x.CountryId==countryId).ToList(); 
              return statelist;
             }
        }
        public List<City> GetCityList(int stateId)
        {
             using (var context = new BlogDBContext()){

              var citylist = context.Cities.Where(x=>x.StateId==stateId).ToList(); 
              return citylist;
             }
        }
        public User Login(UserViewModel AccountModel)
        {
            using (var context = new BlogDBContext())
            {
              return context.Users.Where(x => x.EmailId== AccountModel.Email).FirstOrDefault();
            }
        }
        public List<User> GetUserList()
        {
    using(var _ctx =new BlogDBContext()){
            var userAccount = from stu in _ctx.Users.Where(x => x.RoleId == 5) select stu;
             return _ctx.Users.Include(x=>x.Country).Include(x=>x.State).Include(x=>x.City).ToList();
}
        }
         public bool VerifyEmail(string email)
        {
             using (var context = new BlogDBContext()){

            return context.Users.Any(x => x.EmailId == email);
             }
        }
    }
}