using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.Abstract
{
    public interface IPostService:IGenericService<Post>
    {
        List<Post> GetAllWithBook();
        void DeleteById(int id);
        CategoryVM GetCategoryByBook(int? bookId);
        Category GetCategoryById(int categoryId);
        List<Category> GetCategoriesByFilter(Expression<Func<Category, bool>> filter);
        Book GetBookById(int bookId);
        List<Book> GetBooksByFilter(Expression<Func<Book, bool>> filter);
        int GetUserIdByUserName(string username);
    }
}
