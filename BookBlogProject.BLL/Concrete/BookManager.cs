using BookBlogProject.BLL.Abstract;
using BookBlogProject.DAL.Abstract;
using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.Concrete
{
    public class BookManager : IBookService
    {
        IBookDAL _bookDal;

        public BookManager(IBookDAL bookDal)
        {
            _bookDal = bookDal;
        }
        public void Add(Book entity)
        {
            _bookDal.Add(entity);
        }

        public void AddToBookAuthors(int bookId, List<int> authorIds)
        {
            _bookDal.AddToBookAuthors(bookId, authorIds);
        }

        public void Delete(Book entity)
        {
            entity.BookStatus = false;
            _bookDal.Delete(entity);
        }

        public void DeleteById(int id)
        {
            _bookDal.DeleteById(id);
        }

        public void DeletePost(Post p)
        {
            _bookDal.DeletePost(p);
        }

        public void DeleteWithAuthor(int bookId, List<AuthorVM> authorId)
        {
            _bookDal.DeleteWithAuthor(bookId, authorId);
        }

        public bool DuplicateRecordControl(Expression<Func<Book, bool>> record)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public List<Book> GetAllByFilter(Expression<Func<Book, bool>> filter)
        {
            return _bookDal.GetAllByFilter(filter);
        }

        public List<AuthorVM> GetAuthorInfo(int bookId)
        {
            return _bookDal.GetAuthorInfo(bookId);
        }

        public List<Author> GetAuthorsByFilter(Expression<Func<Author, bool>> filter)
        {
            return _bookDal.GetAuthorsByFilter(filter);
        }

        //public List<Book> GetBooksByAuthor(int authorId)
        //{
        //    return _bookDal.GetBooksByAuthor(authorId);
        //}

        public List<Book> GetBooksWithPosts()
        {
            return _bookDal.GetBooksWithPosts();
        }

        //public Book GetBookWithPosts(int id)
        //{
        //    return _bookDal.GetBookWithPost(id);
        //}

        public Book GetById(int id)
        {
            return _bookDal.GetById(id);
        }

        public List<Category> GetCategoriesByFilter(Expression<Func<Category, bool>> filter)
        {
            return _bookDal.GetCategoriesByFilter(filter);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _bookDal.GetCategoryById(categoryId);
        }

        public List<Post> GetPostsByFilter(Expression<Func<Post, bool>> filter)
        {
            return _bookDal.GetPostsByFilter(filter);
        }

        public void Update(Book entity)
        {
            _bookDal.Update(entity);
        }

        public void UpdateBookAuthors(int bookId, List<AuthorVM> oldAuthorIds, List<int> newAuthorIds)
        {
            _bookDal.UpdateBookAuthors(bookId, oldAuthorIds, newAuthorIds);
        }
    }
}
