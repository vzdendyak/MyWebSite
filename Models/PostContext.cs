using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Site_Lab12.Models
{
    public class PostContext : DbContext
    {
        public PostContext() : base("DefaultConnection")
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }

    public class MessageContext : DbContext
    {
        public MessageContext() : base("DefaultConnection")
        { }
        public DbSet<UserMessage> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
    } 
    
    public class UserMessage
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public string UserSenderId { get; set; }
        public string UserToSendId { get; set; }
       // [ForeignKey("UserSenderId")]
    //    public ApplicationUser UserSender { get; set; }
    ////    [ForeignKey("UserToSendId")]
    //    public ApplicationUser UserToSend { get; set; }
        public int ChatId{ get; set; }

        [ForeignKey("ChatId")]
        public Chat chat { get; set; }


    }

    public class Chat
    {
        public Chat()
        {
            ChatMessages = new List<UserMessage>();
        }
        public int Id { get; set; }
       
        public string UserFirstId { get; set; }
        public string UserSecondId { get; set; }
        public List<UserMessage> ChatMessages { get; set; }
   //    [ForeignKey("UserFirstId")]
     //   public ApplicationUser UserFirst { get; set; }
     ////   [ForeignKey("UserSecondId")]
     //   public ApplicationUser UserSecond { get; set; }

    }
}