using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Site_Lab12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site_Lab12.Controllers
{
    public class HomeController : Controller
    {
        public static ApplicationDbContext dbContext = new ApplicationDbContext();
        ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult HomePage()
        {
            string name = User.Identity.GetUserId();
            //   var ser = dbContext.ApplicationsUsers.Where(m => m.Email == name);
            var ser2 = userManager.Users.Where(m => m.Id == name).FirstOrDefault();
            if (ser2!=null)
            {
                return View(ser2);

            }
            return View(ser2);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            string name = User.Identity.GetUserId();
            //   var ser = dbContext.ApplicationsUsers.Where(m => m.Email == name);
            var ser2 = userManager.Users.Where(m => m.Id == name).FirstOrDefault();
            if (ser2 != null)
            {
                return View(ser2);

            }
            return View(ser2);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
            string name = User.Identity.GetUserId();
            var ser = userManager.Users.Where(m => m.Id == name).FirstOrDefault();
            ser.Email = user.Email;
            ser.UserName = user.UserName;
            ser.PhoneNumber = user.PhoneNumber;
            userManager.UpdateAsync(ser);
            dbContext.SaveChanges();

            return RedirectToAction("HomePage");
        }
        public async System.Threading.Tasks.Task<ActionResult> Edit2Async()
        {
            var ser = await userManager.FindByIdAsync(User.Identity.GetUserId());
            if (ser != null)
            {
                return View(ser);
            }
            else
            {


                return RedirectToAction("HomePage");
            }
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit2Async(ApplicationUser user)
        {
            var ser = await userManager.FindByIdAsync(User.Identity.GetUserId());
            if (ser!=null)
            {
                ser.Email = user.Email;
                ser.UserName = user.UserName;
                ser.PhoneNumber = user.PhoneNumber;
                IdentityResult res = await userManager.UpdateAsync(ser);
                if (res.Succeeded)
                {
                    return RedirectToAction("HomePage");
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}