using BookBlogProject.BLL.Concrete;
using BookBlogProject.BLL.ValidationRules;
using BookBlogProject.DAL.EntityFramework;
using BookBlogProject.EntityLayer.Concrete;
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
    [Authorize(Roles = "A")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());       
        public ActionResult Index(int p=1)
        {

            var result = cm.GetCategorywithBooks().ToPagedList(p, 5);
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Status = Status();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category c)
        {
            CategoryValidator cValidator = new CategoryValidator();
            ValidationResult result = cValidator.Validate(c);

            if (result.IsValid)
            {
                cm.Add(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.Status = Status();

                return View();
            }

        }

        public JsonResult Delete(int id)
        {       
            bool result = false;
            var cat = cm.GetById(id);
            if (cat!=null)
            {
                result = true;
                var posts = cm.GetPostsByFilter(x => x.CategoryID == id);
                foreach (var item in posts)
                {
                    cm.DeletePost(item);
                }

                var books = cm.GetBooksByFilter(x => x.CategoryID == id);
                foreach (var item in books)
                {
                    cm.DeleteBook(item);
                }
                cm.Delete(cat);
            }
            return Json(result);

        }

        public ActionResult Details(int id)
        {
            var result = cm.GetById(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = cm.GetById(id);
            ViewBag.Status = Status();
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Category c)
        {
            CategoryValidator cValidator = new CategoryValidator();
            ValidationResult result = cValidator.Validate(c);

            if (result.IsValid)
            {
                cm.Update(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.Status = Status();

                return View();
            }
        }

        public ActionResult BooksByCategory(int id)
        {
            var result = cm.GetBooksByFilter(x => x.CategoryID == id);
            return View(result);
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
    }
}