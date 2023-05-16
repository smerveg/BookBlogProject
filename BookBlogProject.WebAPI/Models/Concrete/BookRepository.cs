using BookBlogProject.WebAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookBlogProject.WebAPI.Models.Abstract;

namespace BookBlogProject.WebAPI.Models.Concrete
{
    public class BookRepository : IBookRepository
    {  
        public List<BookDTO> GetAllBook()
        {
            using (var db=new BookBlogDBEntities())
            {
                var result=(from b in db.Books
                            select new BookDTO
                            {
                                BookID=b.BookID,
                                BookName=b.BookName,
                                BookStatus=b.BookStatus


                            }).ToList();
                return result;
            }
        }
       
        public BookDetailDTO GetBookById(int bookId)
        {
            using (var db=new BookBlogDBEntities())
            {
               
                var result = (from b in db.Books.Include(x=>x.Authors)
                              where b.BookID == bookId
                              select new BookDetailDTO
                              {
                                  BookID = b.BookID,
                                  BookName = b.BookName,
                                  BookDescription = b.BookDescription,
                                  BookStatus = b.BookStatus,
                                  CategoryName = b.Category.CategoryName,
                                  AuthorList=b.Authors.ToList(),
                                  PageCount = b.PageCount,
                                  Publisher = b.Publisher,
                                  ReleaseYear = b.ReleaseYear
                              }).FirstOrDefault();
                return result;
            }
            

        }

        
    }
}