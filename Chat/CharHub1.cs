using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using Site_Lab12.Controllers;
using Site_Lab12.Models;

namespace Site_Lab12
{
    public class ChatHub : Hub
    {
        public static ApplicationDbContext dbContext = new ApplicationDbContext();
        ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
        PostContext postContext = new PostContext();
        MessageContext messageContext = new MessageContext();
       
        static List<ApplicationUser> Users = new List<ApplicationUser>();
        // Отправка сообщений
        public void Send(string senderId,string toSendId, string message)
        {

            var userSender = userManager.Users.Where(m => m.Id == senderId).FirstOrDefault();
            var userRecipient = userManager.Users.Where(m => m.Id == toSendId).FirstOrDefault();
            var currentChat = messageContext.Chats.Where(m => (m.UserFirstId == senderId && m.UserSecondId == toSendId) || (m.UserFirstId == toSendId && m.UserSecondId == senderId)).FirstOrDefault();
           
            UserMessage newMessage = new UserMessage {                                                        ChatId=currentChat.Id, 
                                                       MessageText=message, 
                                                       senderUserName=userSender.UserName,
                                                       toSendUserName= userRecipient.UserName,
                                                       UserSenderId=userSender.Id,
                                                       UserToSendId = userRecipient.Id
                                                      };
            messageContext.Messages.Add(newMessage);
            messageContext.SaveChanges();
            dbContext.SaveChanges();
            Clients.Group($"{currentChat.Id}-group").addMessage(userSender.UserName, message);
            //Clients.Client(userSender.ConnectionId).addMessage(userSender.UserName,message);
            //Clients.Client(userRecipient.ConnectionId).addMessage(userSender.UserName, message);

            //Clients.All.addMessage(name, message);
        }

        // Подключение нового пользователя
        public Task Connect(string senderId,string toSendId)
        {
            var id = Context.ConnectionId;
            var currentChat = messageContext.Chats.Where(m => (m.UserFirstId == senderId && m.UserSecondId == toSendId)
                                                            ||((m.UserFirstId == toSendId && m.UserSecondId == senderId))).FirstOrDefault();
            if (currentChat!=null)
            {
                return Groups.Add(id,$"{currentChat.Id}-group");
            }
            return null;
            //if (!Users.Any(x => x.ConnectionId == id))
            //{
            //    Users.Add(new ApplicationUser { ConnectionId = id, UserName = userName });

            //    Посылаем сообщение текущему пользователю
            //    Clients.Caller.onConnected(id, userName, Users);

            //    Посылаем сообщение всем пользователям, кроме текущего
            //    Clients.AllExcept(id).onNewUserConnected(id, userName);
            //}
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