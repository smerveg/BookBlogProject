using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.DAL.Abstract
{
    public interface IHomeDAL
    {
        //List<PostVM> GetPosts();
        List<PostVM> GetPosts(int? id);
        List<Author> GetAuthors();
        List<BookVM> GetBooks(int? id);
        List<Person> GetPostWriters();
        Author AuthorInfo(int id);
        BookVM GetBookById(int id);
        PostVM GetPostById(int id);
        
        
    }
}
