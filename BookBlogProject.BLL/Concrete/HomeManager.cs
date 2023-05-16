using BookBlogProject.BLL.Abstract;
using BookBlogProject.DAL.Abstract;
using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.Concrete
{
    public class HomeManager : IHomeService
    {
        IHomeDAL _homeDal;
        public HomeManager(IHomeDAL homeDal)
        {
            _homeDal = homeDal;
        }

        public Author AuthorInfo(int id)
        {
            return _homeDal.AuthorInfo(id);
        }

        public List<Author> GetAuthors()
        {
            return _homeDal.GetAuthors();
        }

        public BookVM GetBookById(int id)
        {
            return _homeDal.GetBookById(id);
        }

        public List<BookVM> GetBooks(int? id)
        {
            return _homeDal.GetBooks(id);
        }

        public PostVM GetPostById(int id)
        {
            return _homeDal.GetPostById(id);
        }

        //public List<PostVM> GetPosts()
        //{
        //    return _homeDal.GetPosts();
        //}

        public List<PostVM> GetPosts(int? id)
        {
            return _homeDal.GetPosts(id);
        }

        public List<Person> GetPostWriters()
        {
            return _homeDal.GetPostWriters();
        }
    }
}
