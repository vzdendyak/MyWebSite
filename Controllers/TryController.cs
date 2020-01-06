using Microsoft.AspNet.Identity.EntityFramework;
using Site_Lab12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site_Lab12.Chat;
using Microsoft.AspNet.Identity;

namespace Site_Lab12.Controllers
{
    public class TryController : Controller
    {
        public static ApplicationDbContext dbContext = new ApplicationDbContext();
        ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
        PostContext postContext = new PostContext();
        ChatHub chat = new ChatHub();
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
        public void SendMessage(string id)
        {
            string IdS = User.Identity.GetUserId();
            var userSender = userManager.Users.Where(m => m.Id == IdS).FirstOrDefault();
            var userToSend = userManager.Users.Where(m => m.Id == id).FirstOrDefault();
            var context = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            chat.Connect(userToSend.UserName);
            chat.Connect(userSender.UserName);

        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}