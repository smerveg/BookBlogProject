using BookBlogProject.WebAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.WebAPI.Models.Abstract
{
    public interface IAuthorRepository
    {
        Author AddAuthor(Author a);
        Author UpdateAuthor(Author a);
        AuthorDTO GetAuthorById(int id);
        Author DeleteAuthor(Author a);
    }
}
