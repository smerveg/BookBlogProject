using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.DAL.Abstract
{
    public interface ICategoryDAL:IRepository<Category>
    {
       
        List<Book> GetBooksByFilter(Expression<Func<Book, bool>> filter);
        void DeleteBook(Book b);
        List<Post> GetPostsByFilter(Expression<Func<Post, bool>> filter);
        void DeletePost(Post p);
        List<Category> GetCategorywithBooks();
    }
}
