using BookBlogProject.WebAPI.Models.Abstract;
using BookBlogProject.WebAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookBlogProject.WebAPI.Models.Concrete
{
    public class AuthorRepository:IAuthorRepository
    {
        public Author AddAuthor(Author a)
        {
            using (var db = new BookBlogDBEntities())
            {
                var x = db.Entry(a);
                x.State = EntityState.Added;
                db.SaveChanges();
                return a;
            }
        }
        public Author UpdateAuthor(Author a)
        {
            using (var db = new BookBlogDBEntities())
            {
                var e = db.Entry(a);
                e.State = EntityState.Modified;
                db.SaveChanges();
                return a;
            }
        }
        public AuthorDTO GetAuthorById(int authorId)
        {
            using (var db = new BookBlogDBEntities())
            {
                var result = (from a in db.Authors
                              where a.AuthorID == authorId
                              select new AuthorDTO
                              {
                                  AuthorName = a.AuthorName,
                                  AuthorLastName = a.AuthorLastName,
                                  AuthorBiography = a.AuthorBiography,
                                  AuthorStatus = a.AuthorStatus
                              }
                            ).FirstOrDefault();
                return result;
            }
        }

        public Author DeleteAuthor(Author a)
        {
            using (var db = new BookBlogDBEntities())
            {
                a.AuthorStatus = false;
                var e = db.Entry(a);
                e.State = EntityState.Modified;
                db.SaveChanges();
                return a;
            }
        }
    }
}