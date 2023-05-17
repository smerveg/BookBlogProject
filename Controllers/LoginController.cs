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
using System.Web.Security;

namespace BookBlogProject.Controllers
{
    
    public class LoginController : Controller
    {
        PersonManager pm = new PersonManager(new EFPersonDAL());

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Log in to start your session";
            return View();
        }

        [HttpPost]
        public ActionResult Login(Person p)
        {
            var person = pm.GetAllByFilter(x => x.Mail == p.Mail).FirstOrDefault();
            if (person!=null)
            {
                var result = pm.PasswordVerification(p.Password, person.Password);
                if (p.Mail == person.Mail && result == true)
                {
                    FormsAuthentication.SetAuthCookie(person.UserName, false);
                    Session["UserName"] = person.UserName;
                    if (person.RoleID==1006 && person.PersonStatus==false)
                    {
                        return RedirectToAction("DefaultUser");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    
                }
                else
                {
                    ViewBag.Message = "Mail Address or Password is wrong.";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Mail Address or Password is wrong.";
                return View();
            }
            
            
            
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Person p)
        {
            p.RoleID = 1006; //default user role id
            PersonValidator pValidator = new PersonValidator();
            ValidationResult result = pValidator.Validate(p);

            if (result.IsValid)
            {
                p.Password=pm.PasswordEncryption(p.Password);
                p.PersonStatus = false;
                pm.Add(p);
                FormsAuthentication.SetAuthCookie(p.UserName, false);
                Session["UserName"] = p.UserName;                
                return RedirectToAction("DefaultUser");
;            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
                return View(p);
            }
            
        }

        [Authorize(Roles="DU")]
        public ActionResult DefaultUser()
        {
            ViewBag.UserName = Session["UserName"];
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }


    }
}