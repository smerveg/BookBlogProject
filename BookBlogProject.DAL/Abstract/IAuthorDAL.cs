using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.DAL.Abstract
{
    public interface IAuthorDAL:IRepository<Author>
    {
        List<Book> GetBooksByAuthor(int authorId);
        List<Author> GetAuthorWithBooks();
    }
}
