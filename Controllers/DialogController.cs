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
    [Authorize]
    public class DialogController : Controller
    {
        public static ApplicationDbContext dbContext = new ApplicationDbContext();
        ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
   //     PostContext postContext = new PostContext();
      //  ChatHub chat = new ChatHub();
        MessageContext messageContext = new MessageContext();
        // GET: Dialog
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Dialog(string userId)
        {
            string currentUserId = User.Identity.GetUserId();
            var ser = userManager.Users.Where(m => m.Id == userId).FirstOrDefault();
            if (userId != null)
            {
                var currentChat = messageContext.Chats.Where(m => (m.UserFirstId == userId && m.UserSecondId == currentUserId) || (m.UserFirstId == currentUserId && m.UserSecondId == userId)).FirstOrDefault();
                if (currentChat == null)
                {
                    Models.Chat chat = new Models.Chat { UserFirstId = currentUserId, UserSecondId = userId };
                    currentChat = chat;
                    messageContext.Chats.Add(currentChat);
                    messageContext.SaveChanges();
                    dbContext.SaveChanges();
                }
                currentChat = messageContext.Chats.Where(m => (m.UserFirstId == userId && m.UserSecondId == currentUserId) || (m.UserFirstId == currentUserId && m.UserSecondId == userId)).FirstOrDefault();
                var messages = messageContext.Messages.Where(m => (m.UserSenderId == currentUserId && m.UserToSendId == userId)||(m.UserToSendId == currentUserId && m.UserSenderId == userId)).ToList();
                ViewData["senderId"] = currentUserId;
                ViewData["recipientId"] = userId;
                ViewData["recipientName"] = ser.UserName;

                return View(messages);
                }
               
                
            
            return RedirectToAction("Index", "Home");
        }
    }
}