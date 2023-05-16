using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookBlogProject.DAL.Concrete
{
    public class Context:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
            .HasRequired(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryID)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<Post>()
            .HasRequired(e => e.Book)
            .WithMany()
            .HasForeignKey(e => e.BookID)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<Post>()
            .HasRequired(e => e.Person)
            .WithMany()
            .HasForeignKey(e => e.PersonID)
            .WillCascadeOnDelete(false);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        
    }
}
