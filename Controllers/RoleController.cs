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
    public class RoleController : Controller
    {
        RoleManager rm = new RoleManager(new EFRoleDAL());
       
        public ActionResult Index(int p=1)
        {
            var result = rm.GetAll().ToPagedList(p, 5);
            return View(result);
        }

        public ActionResult UsersByRole(int? id)
        {
            var result=rm.GetAllUsersByFilter(x => x.RoleID == id);

            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Status = Status();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Role r)
        {
            RoleValidator rValidator = new RoleValidator();
            ValidationResult result = rValidator.Validate(r);

            if (result.IsValid)
            {
                rm.Add(r);
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
            var result = rm.GetById(id);
            if (result != null)
            {
                flag = true;
                var people = rm.GetAllUsersByFilter(x => x.RoleID==id);
                foreach (var item in people)
                {
                    rm.DeleteUser(item);
                }
                rm.Delete(result);
            }

            return Json(flag);
        }

        public ActionResult Details(int id)
        {
            var result = rm.GetById(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = rm.GetById(id);
            ViewBag.Status = Status();
            return View(result);
        }
        
        [HttpPost]
        public ActionResult Update(Role r)
        {
            RoleValidator rValidator = new RoleValidator();
            ValidationResult result = rValidator.Validate(r);

            if (result.IsValid)
            {
                rm.Update(r);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.Status = Status();
                return View(r);
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


    }
}