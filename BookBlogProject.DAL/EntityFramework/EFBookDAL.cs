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
    public class EFBookDAL : GenericRepository<Book>, IBookDAL
    {
        public void AddToBookAuthors(int bookId, List<int> authorIds)
        {

            using (var c=new Context())
            {            
                Book bo = new Book { BookID = bookId };
                bo.Authors = new List<Author>();
                c.Books.Add(bo);
                c.Books.Attach(bo);
                

                foreach (var item in authorIds)
                {
                    Author au = new Author { AuthorID = item };
                    c.Authors.Add(au);
                    c.Authors.Attach(au);

                    
                    bo.Authors.Add(au);
                }
               
                c.SaveChanges();

            }
        }

        public List<Book> GetBooksWithPosts()
        {
            using (var c=new Context())
            {
                return c.Books.Include(x=>x.Posts).ToList();
            }
            
        }
       

        public List<AuthorVM> GetAuthorInfo(int bookId)
        {
            using (var c=new Context())
            {
                var result = (from a in c.Books

                              from b in a.Authors

                              join x in c.Authors on b.AuthorID equals x.AuthorID
                              where a.BookID == bookId
                              select new AuthorVM
                              {
                                  AuthorID = x.AuthorID,
                                  AuthorFullName = x.AuthorName + " " + x.AuthorLastName
                              }).ToList();

                return result;
            }
        }

        public void DeleteWithAuthor(int bookId, List<AuthorVM> authorIds)
        {
            using (var c=new Context())
            {
                var book = c.Books.Include(k=>k.Authors).FirstOrDefault(b => b.BookID == bookId);
                foreach (var item in authorIds)
                {
                    
                    var author = c.Authors.FirstOrDefault(a => a.AuthorID == item.AuthorID);

                    book.Authors.Remove(author);
                }
                
         
                c.SaveChanges();

            }
        }

        public void UpdateBookAuthors(int bookId, List<AuthorVM> oldAuthorIds, List<int> newAuthorIds)
        {
            DeleteWithAuthor(bookId, oldAuthorIds);
            AddToBookAuthors(bookId, newAuthorIds);
        }

       public void DeleteById(int id)
        {
            using (var c=new Context())
            {
                var result = c.Books.Where(x => x.CategoryID == id).ToList();

                foreach (var item in result)
                {
                    item.CategoryID = null;
                    c.SaveChanges();
                    var authorList = GetAuthorInfo(item.BookID);
                    DeleteWithAuthor(item.BookID, authorList);
                }
                
            }
        }

        public List<Author> GetAuthorsByFilter(Expression<Func<Author, bool>> filter)
        {
            using (var c=new Context())
            {
                return c.Authors.Where(filter).ToList();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            using (var c=new Context())
            {
                return c.Categories.Find(categoryId);
            }
        }

        public List<Category> GetCategoriesByFilter(Expression<Func<Category, bool>> filter)
        {
            using (var c=new Context())
            {
                return c.Categories.Where(filter).ToList();
            }
        }

        public List<Post> GetPostsByFilter(Expression<Func<Post, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Posts.Where(filter).ToList();
            }
        }

        public void DeletePost(Post p)
        {
            using (var c=new Context())
            {
                p.PostStatus = false;
                var post = c.Entry(p);
                post.State = EntityState.Modified;
                c.SaveChanges();
            }
        }
    }
}
