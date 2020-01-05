using Microsoft.AspNet.Identity.EntityFramework;
using Site_Lab12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_Lab12.Controllers
{
    public class TryController : Controller
    {
        public static ApplicationDbContext dbContext = new ApplicationDbContext();
        ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
        PostContext postContext = new PostContext();
        // GET: Try
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UsersList1()
        {
            
            return View();
        }
        public ActionResult ComentSearch(int postId)
        {
            //var coments = postContext.Comments.Where(m => m.PostId == postId).ToList();

            return PartialView();
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}