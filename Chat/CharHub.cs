using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using Site_Lab12.Models;

namespace Site_Lab12
{
    public class ChatHub : Hub
    {
        public static ApplicationDbContext dbContext = new ApplicationDbContext();
        public ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
        static List<ApplicationUser> Users = new List<ApplicationUser>();
        static List<ApplicationUser> ActionUsers = new List<ApplicationUser>();


        // Отправка сообщений
        public void Send(string name, string message)
        {

            Clients.Client(Context.ConnectionId).addMessage(name, message);
        }

        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;


            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new ApplicationUser { ConnectionId = id, UserName = userName });
                var ser = userManager.Users.Where(m => m.UserName == userName).FirstOrDefault();
                ser.ConnectionId = id;
                IdentityResult result =  userManager.Update(ser);
                ActionUsers.Add(new ApplicationUser { ConnectionId = id, UserName = userName });
                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, ActionUsers);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}