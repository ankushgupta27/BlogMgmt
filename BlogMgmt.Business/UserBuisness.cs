using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMgmt.Business;
using BlogMgmt.Data.Entities;
using BlogMgmt.Repository;
using BlogMgmt.Models;
using BlogMgmt.Models.ViewModels;



namespace BlogMgmt.Business
{
    public class UserBuisness : IUserBusiness
    {
        public readonly IUserRepository _iUserRepository;
        public UserBuisness(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }
        public bool AddUser(UserViewModel user)
        {

            return _iUserRepository.AddUser(user);
        }

        public List<Country> GetCountryList()
        {
            return _iUserRepository.GetCountryList();
        }
        public List<State> GetStateList(int countryId)
        {
            return _iUserRepository.GetStateList(countryId);
        }

        public List<City> GetCityList(int stateId)
        {
            return _iUserRepository.GetCityList(stateId);
        }

        public User Login(UserViewModel AccountModel)
        {
            return _iUserRepository.Login(AccountModel);
        }
        public List<User> GetUserList()
        {
            return _iUserRepository.GetUserList();
        }
        public bool VerifyEmail(string email)
        {
            return _iUserRepository.VerifyEmail(email);
        }

    }
}
