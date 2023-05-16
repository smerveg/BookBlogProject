using BookBlogProject.DAL.Abstract;
using BookBlogProject.DAL.Concrete;
using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.DAL.EntityFramework
{
    public class EFCategoryDAL:GenericRepository<Category>,ICategoryDAL
    {
        public void DeleteBook(Book b)
        {
            using (var c=new Context())
            {
                b.BookStatus = false;
                var book = c.Entry(b);
                book.State = EntityState.Modified;
                c.SaveChanges();

            }
        }

        public void DeletePost(Post p)
        {
            using (var c = new Context())
            {
                p.PostStatus = false;
                var post = c.Entry(p);
                post.State = EntityState.Modified;
                c.SaveChanges();

            }
        }

        public List<Book> GetBooksByFilter(Expression<Func<Book, bool>> filter)
        {
            using (var c=new Context())
            {
                return c.Books.Where(filter).ToList();
            }
        }


        public List<Category> GetCategorywithBooks()
        {
            using (var c=new Context())
            {
                return c.Categories.Include(x=>x.Books).ToList();
            }
        }

        public List<Post> GetPostsByFilter(Expression<Func<Post, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Posts.Where(filter).ToList();
            }
        }
    }
}
