using BookBlogProject.BLL.Abstract;
using BookBlogProject.DAL.Abstract;
using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDAL _authorDal;
        public AuthorManager(IAuthorDAL authorDal)
        {
            _authorDal = authorDal;
        }
        public void Add(Author entity)
        {
            _authorDal.Add(entity);
        }

        public void Delete(Author entity)
        {
            entity.AuthorStatus = false;
            _authorDal.Delete(entity);
        }

        public List<Author> GetAll()
        {
            return _authorDal.GetAll();
        }

        public List<Author> GetAllByFilter(Expression<Func<Author, bool>> filter)
        {
            return _authorDal.GetAllByFilter(filter);
        }

        public Author GetById(int id)
        {
            return _authorDal.GetById(id);
        }

        public void Update(Author entity)
        {
            _authorDal.Update(entity);
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            return _authorDal.GetBooksByAuthor(authorId);
        }

        public bool DuplicateRecordControl(Expression<Func<Author, bool>> record)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAuthorWithBooks()
        {
            return _authorDal.GetAuthorWithBooks();
        }
    }
}
