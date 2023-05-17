using BookBlogProject.BLL.Concrete;
using BookBlogProject.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookBlogProject.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.UserName = Session["UserName"];
            return View();
        }

        
    }
}