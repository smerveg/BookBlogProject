using BookBlogProject.BLL.Concrete;
using BookBlogProject.BLL.Mappers;
using BookBlogProject.BLL.ValidationRules;
using BookBlogProject.DAL.EntityFramework;
using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BookBlogProject.Controllers
{
    
    public class PostController : Controller
    {
        PostManager pm = new PostManager(new EFPostDAL());

        [Authorize(Roles = "A,PA,E")]
        public ActionResult Index(int p=1)
        {
            string userName = Session["UserName"].ToString();
            ViewBag.UserID = pm.GetUserIdByUserName(userName);
            var result = pm.GetAllWithBook().ToPagedList(p, 5);
            return View(result);
        }

        [Authorize(Roles = "A,PA")]
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Categories = Categories();
            ViewBag.Books = Books();
            ViewBag.Status = Status();

            return View();
        }

        [HttpPost]
        public ActionResult Add(Post p)
        {            
            PostValidator pValidator = new PostValidator();
            ValidationResult result = pValidator.Validate(p);

            if (result.IsValid)
            {
                string userName = Session["UserName"].ToString();
                p.PersonID = pm.GetUserIdByUserName(userName);
                p.PostDate = DateTime.Now;
                p.CategoryID = pm.GetCategoryByBook(p.BookID).CategoryID;
                pm.Add(p);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.Categories = Categories();
                ViewBag.Books = Books();
                ViewBag.Status = Status();
                return View(p);
            }

        }

        [Authorize(Roles = "A,PA,E")]
        public ActionResult Details(int id)
        {
            var result = pm.GetById(id);

            PostVM pvm = GenericMapper<Post, PostVM>.Map(result);
            pvm.BookName = pm.GetBookById(pvm.BookID).BookName;
            pvm.CategoryName = pm.GetCategoryById(pvm.CategoryID).CategoryName;
            return View(pvm);
        }
        
        public JsonResult Delete(int id)
        {
            bool flag = false;
            var result = pm.GetById(id);
            if (result!=null)
            {
                flag = true;
                pm.Delete(result);
                
            }
            return Json(flag);
        }

        [Authorize(Roles = "A,PA")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            Post post = pm.GetById(id);

            PostVM pvm = GenericMapper<Post, PostVM>.Map(post);
            pvm.BookName =pm.GetBookById(pvm.BookID).BookName;
            //pvm.CategoryName = cm.GetById(pvm.CategoryID).CategoryName;

            //ViewBag.Categories = Categories();
            ViewBag.Books = Books();
            ViewBag.Status = Status();

            return View(pvm);

        }
        
        [HttpPost]
        public ActionResult Update(PostVM pvm)
        {
            Post post = GenericMapper<PostVM, Post>.Map(pvm);

            PostValidator pvalidator = new PostValidator();
            ValidationResult result = pvalidator.Validate(post);

            if (result.IsValid)
            {
                pm.Update(post);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.Books = Books();
                ViewBag.Status = Status();
                return View(pvm);
            }
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
        private List<SelectListItem> Categories()
        {
            List<SelectListItem> categoryList = (from c in pm.GetCategoriesByFilter(x => x.CategoryStatus == true)
                                                 select new SelectListItem
                                                 {
                                                     Text = c.CategoryName,
                                                     Value = c.CategoryID.ToString()
                                                 }).ToList();
            return categoryList;
                
                
        }
        private List<SelectListItem> Books()
        {
            List<SelectListItem> bookList = (from b in pm.GetBooksByFilter(x => x.BookStatus == true)
                                         select new SelectListItem
                                         {
                                             Text = b.BookName,
                                             Value = b.BookID.ToString()
                                         }).ToList();
            return bookList;


        }
    }
}