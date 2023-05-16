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
    public class PostManager : IPostService
    {
        IPostDAL _postDal;

        public PostManager(IPostDAL postDal)
        {
            _postDal = postDal;
        }
        public void Add(Post entity)
        {
            _postDal.Add(entity);
        }

        public void Delete(Post entity)
        {
            entity.PostStatus = false;
            _postDal.Delete(entity);
        }

        public void DeleteById(int id)
        {
             _postDal.DeleteById(id);
        }

        public bool DuplicateRecordControl(Expression<Func<Post, bool>> record)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAll()
        {
            return _postDal.GetAll();
        }

        public List<Post> GetAllByFilter(Expression<Func<Post, bool>> filter)
        {
            return _postDal.GetAllByFilter(filter);
        }

        public List<Post> GetAllWithBook()
        {
            return _postDal.GetAllWithBook();
        }

        public Book GetBookById(int bookId)
        {
            return _postDal.GetBookById(bookId);
        }

        public List<Book> GetBooksByFilter(Expression<Func<Book, bool>> filter)
        {
            return _postDal.GetBooksByFilter(filter);
        }

        public Post GetById(int id)
        {
            return _postDal.GetById(id);
        }

        public List<Category> GetCategoriesByFilter(Expression<Func<Category, bool>> filter)
        {
            return _postDal.GetCategoriesByFilter(filter);
        }

        public CategoryVM GetCategoryByBook(int? bookId)
        {
            return _postDal.GetCategoryByBook(bookId);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _postDal.GetCategoryById(categoryId);
        }

        public void Update(Post entity)
        {
            _postDal.Update(entity);
        }
        public int GetUserIdByUserName(string username)
        {
            return _postDal.GetUserIdByUserName(username);
        }
    }
}
