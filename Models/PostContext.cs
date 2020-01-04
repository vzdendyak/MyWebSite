using System;
using System.Collections.Generic;
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

    }
}