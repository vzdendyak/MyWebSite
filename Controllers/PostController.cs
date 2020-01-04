using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Site_Lab12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_Lab12.Controllers
{
    public class PostController : Controller
    {

        public static ApplicationDbContext dbContext = new ApplicationDbContext();
        ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
        PostContext postContext = new PostContext();
        // GET: Post
        public ActionResult My()
        {
            Post p1 = new Post { BodyText = "Lorem ipsum", AuthorId = User.Identity.GetUserId(), Title = "MyPost", Date = DateTime.Now };
            postContext.Posts.Add(p1);
            postContext.SaveChanges();
            string Id = User.Identity.GetUserId();
            var posts = postContext.Posts.Where(m => m.AuthorId == Id).ToList();
            return View(posts);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var post = postContext.Posts.Where(m => m.Id == id).FirstOrDefault();

            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
