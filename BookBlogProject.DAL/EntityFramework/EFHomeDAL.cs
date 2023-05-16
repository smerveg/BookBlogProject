using BookBlogProject.DAL.Abstract;
using BookBlogProject.DAL.Concrete;
using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.DAL.EntityFramework
{
    public class EFHomeDAL : IHomeDAL
    {
        public Author AuthorInfo(int id)
        {
            using (var c=new Context())
            {
                return c.Authors.Where(x => x.AuthorID == id).FirstOrDefault();
            }
        }

        public List<Author> GetAuthors()
        {
            using (var c=new Context())
            {
                return c.Authors.Where(x => x.AuthorStatus == true).ToList();
            }
        }

        public BookVM GetBookById(int id)
        {
            BookVM bvm = new BookVM();
            using (var c=new Context())
            {
                var result = c.Books.Where(x => x.BookID == id).FirstOrDefault();
                bvm.BookID = id;
                bvm.BookImage = result.BookImage;
                bvm.BookName = result.BookName;
                bvm.BookDescription = result.BookDescription;
                bvm.PageCount = result.PageCount;
                bvm.Publisher = result.Publisher;
                bvm.ReleaseYear = result.ReleaseYear;
                bvm.CategoryName = GetCategory(c, result.CategoryID);
                bvm.AuthorInfos = GetAuthors(c, id);
            }
            return bvm;
        }

        public List<BookVM> GetBooks(int? id)
        {
            List<BookVM> bookList = new List<BookVM>();
            using (var c=new Context())
            {
                if (id!=null)
                {
                    bookList = (from a in c.Authors

                                  from b in a.Books

                                  join x in c.Books on b.BookID equals x.BookID
                                  where a.AuthorID==id && b.BookStatus==true
                                  select new BookVM
                                  {
                                      BookID=x.BookID,
                                      BookImage = x.BookImage,
                                      BookName=x.BookName,
                                      BookDescription=x.BookDescription
                                  }).ToList();

                  
                }
                else
                {
                    var result = c.Books.Where(x => x.BookStatus == true).ToList();
                    
                    foreach (var item in result)
                    {
                        BookVM bvm = new BookVM();
                        bvm.BookID = item.BookID;
                        bvm.BookImage = item.BookImage;
                        bvm.BookName = item.BookName;
                        bvm.BookDescription = item.BookDescription;
                        bookList.Add(bvm);
                    }

                }

                return bookList;
            }

        }

        public List<PostVM> GetPosts(int? id)
        {
            List<PostVM> postModel = new List<PostVM>();
            List<Post> postList = new List<Post>();

            using (var c = new Context())
            {
                if (id!=null)
                {
                    postList= c.Posts.Where(x => (x.PostStatus == true) && (x.PersonID == id)).ToList();
                }
                else
                {
                    postList = c.Posts.Where(x => x.PostStatus == true).ToList();
                }
                

                foreach (var item in postList)
                {
                    PostVM pvm = new PostVM();
                    pvm.PostID = item.PostID;
                    pvm.BookImage = GetBookInfo(c, item.BookID).BookImage;
                    pvm.BookName = GetBookInfo(c, item.BookID).BookName;
                    pvm.PostTitle = item.PostTitle;
                    pvm.PostDate = item.PostDate;
                    pvm.PostContent = item.PostContent;
                    pvm.PersonID = item.PersonID;
                    pvm.PersonFullName = GetPostAuthorInfo(c, item.PersonID);
                    postModel.Add(pvm);
                }
                return postModel;
            }
        }

        public List<Person> GetPostWriters()
        {
            using (var c=new Context())
            {
                return c.People.Where(x => (x.PersonStatus == true) && (x.RoleID == 3)).ToList();
            }
        }
        public PostVM GetPostById(int id)
        {
            PostVM pvm = new PostVM();

            using (var c=new Context())
            {
                var result = c.Posts.Where(x => x.PostID == id).FirstOrDefault();
                pvm.PostTitle = result.PostTitle;
                pvm.PostContent = result.PostContent;
                pvm.PostDate = result.PostDate;
                pvm.BookImage = GetBookImageURL(c, result.BookID);
                pvm.PersonFullName = GetPostAuthorInfo(c, result.PersonID);
                return pvm;

            }
        }

        private BookVM GetBookInfo(Context c,int bookId)
        {
            BookVM bvm = new BookVM();
            var result= c.Books.Where(x => x.BookID == bookId).FirstOrDefault();
            bvm.BookImage = result.BookImage;
            bvm.BookName = result.BookName;
            return bvm;
            
        }

        private string GetPostAuthorInfo(Context c,int personId)
        {
            
                var result = c.People.Where(x => x.PersonID == personId).FirstOrDefault();
                return result.Name +" "+ result.LastName;
            
        }
        private string GetCategory(Context c,int? categoryId)
        {
            return c.Categories.Where(x => x.CategoryID == categoryId).FirstOrDefault().CategoryName;
        }
        private List<AuthorVM> GetAuthors(Context c,int bookId)
        {
            var result = (from a in c.Books

                          from b in a.Authors

                          join x in c.Authors on b.AuthorID equals x.AuthorID
                          where a.BookID == bookId
                          select new AuthorVM
                          {                             
                              AuthorFullName = x.AuthorName + " " + x.AuthorLastName
                          }).ToList();
            return result;
        }
        private string GetBookImageURL(Context c,int bookId)
        {
            return c.Books.Where(x => x.BookID == bookId).FirstOrDefault().BookImage;
        }
        

        
    }
}
