using Microsoft.AspNet.Identity.EntityFramework;
using Site_Lab12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_Lab12.Chat
{
    public class ContextChatHelp
    {
        public static ApplicationDbContext dbContext = new ApplicationDbContext();
        public static ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
        public static PostContext postContext = new PostContext();
     //   public static ChatHub chat = new ChatHub();
        public static MessageContext messageContext = new MessageContext();

    }
}