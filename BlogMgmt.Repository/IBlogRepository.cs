using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMgmt.Data.Entities;
using BlogMgmt.Models.ViewModels;

namespace BlogMgmt.Repository
{
    public interface IBlogRepository
    {
        List<Blog> GetBlogs(); 
        void AddBlogDetail(Blog blgDetail);
        List<Category> GetCategoryList();
           List<Blog> GetBlogList(string Sorting_Order, string Search_Data);
         public bool EditBlogDetail(EditBlogModel editBlogModel);
          public AddBlogModel GetBlogById(int id);


    }
    

}