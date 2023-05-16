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
    public interface IPostDAL:IRepository<Post>
    {
        List<Post> GetAllWithBook();
        void DeleteById(int id);
        CategoryVM GetCategoryByBook(int? bookId);
        Category GetCategoryById(int categoryId);
        List<Category> GetCategoriesByFilter(Expression<Func<Category,bool>> filter);
        Book GetBookById(int bookId);
        int GetUserIdByUserName(string username);
        List<Book> GetBooksByFilter(Expression<Func<Book, bool>> filter);
    }
}
