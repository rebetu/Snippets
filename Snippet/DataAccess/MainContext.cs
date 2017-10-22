using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Snippet.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Snippet.DataAccess
{
    public class MainContext : DbContext
    {
       // public MainContext(DbContextOptions<MainContext> options) : base(options) { }

       //public MainContext() : this("DefaultConnection") { }

        public MainContext(string connectionString) : base(connectionString)
        { 

        }

        //public static MainContext Create()
        //{
        //    return new MainContext();
        //}

        public MainContext() : base()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MainContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MainContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<SnippetText> Snippets { get; set; }

        public DbSet<SnippetLike> SnippetLikes { get; set; }

        public DbSet<SnippetShare> SnippetShares { get; set; }
    }
}
