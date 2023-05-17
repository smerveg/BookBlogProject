using BookBlogProject.BLL.Concrete;
using BookBlogProject.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BookBlogProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        HomeManager hm = new HomeManager(new EFHomeDAL());

        [OutputCache(CacheProfile ="HomeCache")]
        public ActionResult Homepage(int? id,int p=1)
        {

            var result = hm.GetPosts(id).ToPagedList(p, 5);
            return View(result);
        }

        [OutputCache(CacheProfile = "HomeCache")]
        public ActionResult Authors(int p = 1)
        {
            var result = hm.GetAuthors().ToPagedList(p, 5);
            return View(result);
        }

        [OutputCache(CacheProfile = "HomeCache")]
        public ActionResult Books(int? id, int p = 1)
        {
            var result = hm.GetBooks(id).ToPagedList(p, 5);
            
            return View(result);
        }

        [OutputCache(CacheProfile = "HomeCache")]
        public ActionResult PostWriters(int p = 1)
        {
            var result = hm.GetPostWriters().ToPagedList(p, 5);
            return View(result);
        }

        public ActionResult PostsByWriter(int id, int p = 1)
        {
            var result = hm.GetPosts(id).ToPagedList(p, 5);
            return View(result);
        }

        public ActionResult AboutAuthor(int id)
        {
            var result = hm.AuthorInfo(id);
            return View(result);
        }

        public ActionResult BookDetail(int id)
        {
            var result = hm.GetBookById(id);
            return View(result);
        }

        public ActionResult PostDetail(int id)
        {
            var result = hm.GetPostById(id);
            return View(result);
        }



        
    }
}