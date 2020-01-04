using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_Lab12.Models
{
    public class Post
    {
        
        public int Id { get; set; }
        public string BodyText { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

       public ICollection<Comment> Comments { get; set; }
    }
}