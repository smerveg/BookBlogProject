using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.DAL.Abstract
{
    public interface IBookDAL:IRepository<Book>
    {
        List<Book> GetBooksWithPosts();
        void AddToBookAuthors(int bookId,List<int> authorIds);
        List<AuthorVM> GetAuthorInfo(int bookId);

        void DeleteWithAuthor(int bookId, List<AuthorVM> authorId);
        void UpdateBookAuthors(int bookId, List<AuthorVM> oldAuthorIds, List<int> newAuthorIds);
        void DeleteById(int id);
        //List<Book> GetBooksByAuthor(int authorId);
        List<Author> GetAuthorsByFilter(Expression<Func<Author, bool>> filter);
        Category GetCategoryById(int categoryId);
        List<Category> GetCategoriesByFilter(Expression<Func<Category, bool>> filter);
        List<Post> GetPostsByFilter(Expression<Func<Post, bool>> filter);
        void DeletePost(Post p);

    }
}
