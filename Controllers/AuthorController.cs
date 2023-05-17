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
    
    public class AuthorController : Controller
    {
        AuthorManager aum = new AuthorManager(new EFAuthorDAL());
        
        [Authorize(Roles ="A,E,PA")]
        public ActionResult Index(int p=1)
        {
            var result = aum.GetAuthorWithBooks().ToPagedList(p, 5);
            return View(result);
        }

        [Authorize(Roles = "A,E")]
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Status = Status();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Author a)
        {
            AuthorValidator aValidator = new AuthorValidator();
            ValidationResult result = aValidator.Validate(a);

            if (result.IsValid)
            {
                aum.Add(a);
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
            bool flag = false;
            var result = aum.GetById(id);
            if (result != null)
            {
                flag = true;
                aum.Delete(result);
            }

            return Json(flag);

        }

        [Authorize(Roles = "A,E,PA")]
        public ActionResult Details(int id)
        {
            var result = aum.GetById(id);
            return View(result);
        }

        [Authorize(Roles = "A,E")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = aum.GetById(id);
            ViewBag.Status = Status();
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Author a)
        {
            AuthorValidator aValidator = new AuthorValidator();
            ValidationResult result = aValidator.Validate(a);

            if (result.IsValid)
            {
                aum.Update(a);
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

        [Authorize(Roles = "A,E,PA")]
        public ActionResult BooksByAuthor(int id)
        {
            var result =aum.GetBooksByAuthor(id);
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