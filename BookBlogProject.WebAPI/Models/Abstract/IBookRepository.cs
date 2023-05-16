using BookBlogProject.WebAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.WebAPI.Models.Abstract
{
    public interface IBookRepository
   {
        List<BookDTO> GetAllBook();
        BookDetailDTO GetBookById(int bookId);
        
    }
}
