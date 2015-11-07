using System.Data.Entity;

namespace Snippy.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Snippy.Models;

    public class SnippyDbContext : IdentityDbContext<User>
    {
        public SnippyDbContext()
            : base("SnippyDb", throwIfV1Schema: false)
        {
        }

        public static SnippyDbContext Create()
        {
            return new SnippyDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Snippet>()
                .HasRequired(s => s.Author)
                .WithMany(u => u.Snippets)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Snippet> Snippets { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<Comment> Comments { get; set; } 
    }
}
