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
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDal;

        public CategoryManager(ICategoryDAL categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetAllByFilter(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.GetAllByFilter(filter);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }
        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Delete(Category entity)
        {
            entity.CategoryStatus = false;
            _categoryDal.Delete(entity);
        }        

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public List<Book> GetBooksByFilter(Expression<Func<Book, bool>> filter)
        {
            return _categoryDal.GetBooksByFilter(filter);
        }

        public void DeleteBook(Book b)
        {
            _categoryDal.DeleteBook(b);
        }

        public List<Post> GetPostsByFilter(Expression<Func<Post, bool>> filter)
        {
            return _categoryDal.GetPostsByFilter(filter);
        }

        public void DeletePost(Post p)
        {
            _categoryDal.DeletePost(p);
        }

        public bool DuplicateRecordControl(Expression<Func<Category, bool>> record)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategorywithBooks()
        {
            return _categoryDal.GetCategorywithBooks();
        }

        //public CategoryVM GetCategoryByBook(int? bookId)
        //{
        //    return _categoryDal.GetCategoryByBook(bookId);
        //}
    }
}
