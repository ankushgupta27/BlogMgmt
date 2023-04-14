using BlogMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMgmt.Data.Entities;
using BlogMgmt.Repository;
using BlogMgmt.Business;
using BlogMgmt.Models.ViewModels;

namespace BlogMgmt.Business
{
    public interface IUserBusiness
    {
        bool AddUser(UserViewModel user);
        List<Country> GetCountryList();
        public List<State> GetStateList(int countryId);
        public List<City> GetCityList(int stateId);
        User Login(UserViewModel AccountModel);
        List<User> GetUserList();
        public bool VerifyEmail(string email);
    }
}