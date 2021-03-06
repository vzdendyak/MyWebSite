﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_Lab12.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string BodyText { get; set; }
        public string AuthorId { get; set; }
        public string Author { get; set; }
        public int PostId { get; set; }
        public Post post { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}