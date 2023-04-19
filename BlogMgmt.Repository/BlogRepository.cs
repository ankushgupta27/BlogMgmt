using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMgmt.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using BlogMgmt.Models.ViewModels;

namespace BlogMgmt.Repository
{
    public class BlogRepository : IBlogRepository
    {
        public List<Blog> GetBlogs()
        {
            List<Blog> BlogList = new List<Blog>();
            using (var context = new BlogDBContext())
            {
                BlogList = context.Blogs.ToList();
            }
            return BlogList;
        }
        public void AddBlogDetail(Blog blgDetail)
        {
            using (var context = new BlogDBContext())
            {
                Blog blgInfo = new Blog();
                blgInfo.Title = blgDetail.Title;
                blgInfo.CategoryId = blgDetail.CategoryId;
                blgInfo.Description = blgDetail.Description;
                blgInfo.CreatedBy =  blgDetail.CreatedBy;
                blgInfo.CreatedOn = DateTime.Now;
                blgInfo.UpdatedBy = blgDetail.CreatedBy;
                blgInfo.IsActive = true;
            
                if(blgDetail.Id>0)
                {
                blgInfo.Id=blgDetail.Id;   
                context.Update(blgInfo) ;
                }

            else{
                context.Add(blgInfo);
                }  
                context.SaveChanges();
            }
        }
        public List<Category> GetCategoryList()
        {
            using (var context = new BlogDBContext())
            {

                var categorylist = context.Categories.ToList();
                return categorylist;
            }
        }
        public List<Blog> GetBlogList(string Sorting_Order, string Search_Data)
        {
            List<Blog> BlogList = new List<Blog>();
            using (var context = new BlogDBContext())
            {
                var userAccount = context.Blogs.Include("Category");
                // return BlogList;
                // var userAccount = from stu in context.Blogs select stu;

            if (!string.IsNullOrEmpty(Search_Data))
            {
                userAccount = userAccount.Where(stu => stu.Title.Contains(Search_Data));
            }
            switch (Sorting_Order)
            {
                case "Name_Description":
                    userAccount = userAccount.OrderByDescending(stu => stu.Title);
                    break;
               
                default:
                    userAccount = userAccount.OrderBy(stu => stu.Title);
                    break;
            }
          
            return userAccount.ToList();



            }

        }
        public AddBlogModel GetBlogById(int id)
        {
            using (var context = new BlogDBContext())
            {
                var detail = context.Blogs.FirstOrDefault(x => x.Id == id);
                 AddBlogModel editBlogModel = new AddBlogModel();
                editBlogModel.Title = detail.Title;
                editBlogModel.CategoryId = detail.CategoryId;
                editBlogModel.Description = detail.Description;

                return editBlogModel;
            }
        }
        public bool EditBlogDetail(EditBlogModel editBlogModel)
        {
            using (var context = new BlogDBContext())
            {
                Blog user = new Blog();
                editBlogModel.Title = user.Title;
                editBlogModel.CategoryId = user.CategoryId;
                editBlogModel.Description = user.Description;
           
                editBlogModel.CreatedOn = DateTime.Now;
                editBlogModel.CreatedBy = editBlogModel.CreatedBy;
                editBlogModel.UpdatedBy = editBlogModel.CreatedBy;
                editBlogModel.CreatedOn = DateTime.Now;
                context.Update(user);
                return context.SaveChanges() > 0;
            }
        }
    }
}