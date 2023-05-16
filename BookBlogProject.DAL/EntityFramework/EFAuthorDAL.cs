using BookBlogProject.DAL.Abstract;
using BookBlogProject.DAL.Concrete;
using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookBlogProject.DAL.EntityFramework
{
    public class EFAuthorDAL:GenericRepository<Author>,IAuthorDAL
    {
        public List<Author> GetAuthorWithBooks()
        {
            using (var c=new Context())
            {
                return c.Authors.Include(x => x.Books).ToList();
            }
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            using (var c = new Context())
            {
                List<Book> bookList = new List<Book>();
                bookList = null;
                var books = c.Books.Include(x => x.Authors).ToList();
                Author author = c.Authors.Where(x => x.AuthorID == authorId).FirstOrDefault();

                if (author.Books!=null)
                {
                    bookList = (author.Books).ToList();
                }
                

                return bookList;

            }
        }
    }
}
