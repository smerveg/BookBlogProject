using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.Abstract
{
    public interface IAuthorService:IGenericService<Author>
    {
        List<Author> GetAuthorWithBooks();
        List<Book> GetBooksByAuthor(int authorId);
    }
}
