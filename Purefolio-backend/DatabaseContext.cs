using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Purefolio.DatabaseContext
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
            // TODO: Use a configuration file instead of hard coding database string.
            .UseNpgsql("Host=localhost;Port=10101;Database=purefolio;Username=purefolio;Password=password")
            .UseSnakeCaseNamingConvention();
    }

    // TODO: Remove: Is here to give an example
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    // TODO: Remove: Is here to give an example
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}

