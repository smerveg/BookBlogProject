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
    [Authorize(Roles ="A")]
    public class PersonController : Controller
    {
        PersonManager pm = new PersonManager(new EFPersonDAL());
       
        public ActionResult Index(int p=1)
        {
            
            var result = pm.PeopleWithRoles().ToPagedList(p, 5);
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Roles = Roles();
            ViewBag.Status = Status();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person p)
        {
            PersonValidator pValidator = new PersonValidator();
            ValidationResult result = pValidator.Validate(p);


            if (result.IsValid)
            {               
                    pm.Add(p);
                    return RedirectToAction("Index");
                               
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                ViewBag.Roles = Roles();
                ViewBag.Status = Status();
                return View(p);
            }
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


        public ActionResult Details(int id)
        {
            var result = pm.GetById(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = pm.GetById(id);
            ViewBag.Roles = Roles();
            ViewBag.Status = Status();
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Person p)
        {
            PersonValidator pValidator = new PersonValidator();
            ValidationResult result = pValidator.Validate(p);

            if (result.IsValid)
            {
                pm.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.Roles = Roles();
                ViewBag.Status = Status();

                return View(p);
            }
        }

        private List<SelectListItem> Roles()
        {
            List<SelectListItem> roleList =(from r in pm.GetAllRolesByFilter(x => x.RoleStatus == true)
                                             select new SelectListItem
                                             {
                                                 Text = r.RoleName,
                                                 Value = r.RoleID.ToString(),
                                                 
                                             }
                                           ).ToList();
            
            return roleList;
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
               ) ;

            return status;




        }
   


    }
}