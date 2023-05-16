using BookBlogProject.DAL.Abstract;
using BookBlogProject.DAL.Concrete;
using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BookBlogProject.DAL.EntityFramework
{
    public class EFPostDAL : GenericRepository<Post>, IPostDAL
    {
        public void DeleteById(int id)
        {
            using (var c=new Context())
            {
                var result = c.Posts.Where(x => x.CategoryID == id).ToList();

                foreach (var item in result)
                {
                    c.Posts.Remove(item);
                }
                c.SaveChanges();
                
            }
        }

        public List<Post> GetAllWithBook()
        {
            using (var c = new Context())
            {
                return c.Posts.Include(x => x.Book).ToList();
            }
        }

        public Book GetBookById(int bookId)
        {
            using (var c = new Context())
            {
                return c.Books.Find(bookId);
            }
        }

        public List<Book> GetBooksByFilter(Expression<Func<Book, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Books.Where(filter).ToList();
            }
        }

        public List<Category> GetCategoriesByFilter(Expression<Func<Category, bool>> filter)
        {
            using (var c=new Context())
            {
                return c.Categories.Where(filter).ToList();
            }
        }

        public CategoryVM GetCategoryByBook(int? bookId)
        {
            using (var c = new Context())
            {
                var result = (from b in c.Books
                              join cat in c.Categories on b.CategoryID equals cat.CategoryID
                              where b.BookID == bookId
                              select new CategoryVM
                              {
                                  CategoryName = cat.CategoryName,
                                  CategoryID = cat.CategoryID
                              }).FirstOrDefault();
                return result;
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            using (var c=new Context())
            {
                return c.Categories.Find(categoryId);
            }
        }
        public int GetUserIdByUserName(string username)
        {
            using (var c=new Context())
            {
                return c.People.Where(x => x.UserName == username).FirstOrDefault().PersonID;
            }
        }
    }
}
