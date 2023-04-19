using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMgmt.Repository;
using BlogMgmt.Models.ViewModels;
using BlogMgmt.Data.Entities;


namespace BlogMgmt.Business
{
    public class BlogBusiness : IBlogBusiness
    {
        public readonly IBlogRepository _iBlogRepository;
        public BlogBusiness(IBlogRepository iBlogRepository)
        {
            _iBlogRepository = iBlogRepository;
        }
        public List<Blog> GetBlogs()
        {
            return _iBlogRepository.GetBlogs();
        }
        public void AddBlogDetail(Blog blgDetail)
        {
            _iBlogRepository.AddBlogDetail(blgDetail);
        }
        public List<Category> GetCategoryList(){
            return _iBlogRepository.GetCategoryList();
        }
         public List<Blog> GetBlogList(string Sorting_Order, string Search_Data)
        {
            return _iBlogRepository.GetBlogList(Sorting_Order , Search_Data);
        }
        
         public bool EditBlogDetail(EditBlogModel editBlogModel){
            return _iBlogRepository.EditBlogDetail(editBlogModel);
         }
          public AddBlogModel GetBlogById(int id){
            return _iBlogRepository.GetBlogById(id);
          }

    }
}

