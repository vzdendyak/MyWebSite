using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_Lab12.Models
{
    public class Post
    {
        
        public int Id { get; set; }
        [Display(Name="Вміст")]
        public string BodyText { get; set; }

        public string AuthorId { get; set; }
        [Display(Name = "Заголовок")]

        public string Title { get; set; }
        [Display(Name = "Дата публікації")]

        public DateTime Date { get; set; }

       public ICollection<Comment> Comments { get; set; }
    }
}