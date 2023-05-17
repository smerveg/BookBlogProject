using BookBlogProject.BLL.Concrete;
using BookBlogProject.BLL.Mappers;
using BookBlogProject.BLL.ValidationRules;
using BookBlogProject.DAL.EntityFramework;
using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BookBlogProject.Controllers
{
    public class BookController : Controller
    {
        BookManager bm = new BookManager(new EFBookDAL());

        [Authorize(Roles = "A,E,PA")]
        public ActionResult Index(int p=1)
        {
            var result = bm.GetBooksWithPosts().ToPagedList(p, 5);

            return View(result);
        }

        [Authorize(Roles = "A,E")]
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Status = Status();
            ViewBag.Authors= Authors();
            ViewBag.Categories = Categories();
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookVM bvm)
        {
            Book b = GenericMapper<BookVM, Book>.Map(bvm);

            BookValidator bValidator = new BookValidator();
            ValidationResult result = bValidator.Validate(bvm);

            
            if (result.IsValid)
            {
                b.BookImage = "/Image/" + CreateImagePath();
                bm.Add(b);                                  
                bm.AddToBookAuthors(b.BookID, bvm.SelectedAuthors.ToList());
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.Status = Status();
                ViewBag.Authors = Authors();
                ViewBag.Categories = Categories();
                return View(bvm);
            }
        }

        [Authorize(Roles = "A,E,PA")]
        public ActionResult Details(int id)
        {
            Book book = new Book();
            book = bm.GetById(id);

            BookVM bvm = GenericMapper<Book, BookVM>.Map(book);

            bvm.CategoryName = bm.GetCategoryById(bvm.CategoryID).CategoryName;

            bvm.AuthorInfos = bm.GetAuthorInfo(id);

            return View(bvm);

        }

        public JsonResult Delete(int id)
        {
            bool flag = false;
           var result = bm.GetById(id);

            if (result != null)
            {
                flag = true;
                BookVM bvm = new BookVM();
                
                var posts = bm.GetPostsByFilter(x => x.BookID == id);
                foreach (var item in posts)
                {
                    bm.DeletePost(item);
                }
                bm.Delete(result);
            }

            return Json(flag);
        }

        [Authorize(Roles = "A,E")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            Book book = new Book();
            book = bm.GetById(id);

            BookVM bvm = GenericMapper<Book, BookVM>.Map(book);

            bvm.CategoryName = bm.GetCategoryById(bvm.CategoryID).CategoryName;

            bvm.AuthorInfos = bm.GetAuthorInfo(id);

            List<int> temp = new List<int>();
            foreach (var item in bvm.AuthorInfos)
            {

                temp.Add(item.AuthorID);
            }
            bvm.SelectedAuthors = temp;
            ViewBag.Status = Status();
            ViewBag.Authors = Authors();
            ViewBag.Categories = Categories();

            return View(bvm);
        }

        [HttpPost]
        public ActionResult Update(BookVM bvm)
        {
            Book b = GenericMapper<BookVM, Book>.Map(bvm);
            BookValidator bValidator = new BookValidator();
            ValidationResult result = bValidator.Validate(bvm);
            bvm.AuthorInfos = bm.GetAuthorInfo(b.BookID);

            if (result.IsValid)
            {
                b.BookImage = "/Image/" + CreateImagePath();
                bm.Update(b);
                bm.UpdateBookAuthors(b.BookID,bvm.AuthorInfos, bvm.SelectedAuthors.ToList());
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.Status = Status();
                ViewBag.Authors = Authors();
                ViewBag.Categories = Categories();
                return View(bvm);
            }



            return RedirectToAction("Index");
        }


        private List<SelectListItem> Status()
        {
            List<SelectListItem> status = new List<SelectListItem>();
            status.Add(
                new SelectListItem
                {
                    Text = "True",
                    Value = true.ToString(),
                    Selected = true

                }
               ); ;
            status.Add(
                new SelectListItem
                {
                    Text = "False",
                    Value = false.ToString(),
                    Selected = false

                }
               );

            return status;




        }

        private List<SelectListItem> Authors()
        {
            List<SelectListItem> authorList = (from a in bm.GetAuthorsByFilter(x => x.AuthorStatus == true)
                                               select new SelectListItem
                                               {
                                                   Text = a.AuthorName+" "+a.AuthorLastName,
                                                   Value = a.AuthorID.ToString()
                                               }).ToList();
            return authorList;
        }

        private List<SelectListItem> Categories()
        {
            List<SelectListItem> categoryList = (from c in bm.GetCategoriesByFilter(x => x.CategoryStatus == true)
                          select new SelectListItem
                          {
                              Text = c.CategoryName,
                              Value = c.CategoryID.ToString()
                          }).ToList();
            return categoryList;
        }

        public JsonResult GetAuthorList(int id)
        {
            var selectedAuthorList = bm.GetAuthorInfo(id);

            return Json(selectedAuthorList, JsonRequestBehavior.AllowGet);
        }

        private string CreateImagePath()
        {
            string fileName = null;
            string fileExtension = null;
            string filePath = null;

            if (Request.Files.Count>0)
            {
                
                fileName = Path.GetFileName(Request.Files[0].FileName);
                fileExtension = Path.GetExtension(Request.Files[0].FileName);
                

                    filePath = "~/Image/" + fileName + fileExtension;

                 
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                

            }

            return fileName + fileExtension;


        }
    }
}