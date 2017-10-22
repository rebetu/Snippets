namespace Snippet.Migrations
{
    using Snippet.DataAccess;
    using Snippet.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Snippet.DataAccess.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Snippet.DataAccess.MainContext";
        }

        private MainContext _context;

        protected override void Seed(Snippet.DataAccess.MainContext context)
        {
            _context = context;

            if(!context.AppUsers.Any())
            {
                DatabaseSeeder.Seed(context);
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.AppUsers.AddOrUpdate(x => x.Id,
            //    new AppUser() { CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Email = "user1@email.com" },
            //    new AppUser() { CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Email = "user2@email.com" },
            //    new AppUser() { CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Email = "user3@email.com" },
            //    new AppUser() { CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Email = "user4@email.com" }
            //    );

            //context.SaveChanges();


            //var user1 = context.AppUsers.FirstOrDefault(x => x.Id == 1);
            //var user2 = context.AppUsers.FirstOrDefault(x => x.Id == 2);
            //var user3 = context.AppUsers.FirstOrDefault(x => x.Id == 3);
            //var user4 = context.AppUsers.FirstOrDefault(x => x.Id == 4);

            //context.Snippets.AddOrUpdate(x => x.Id,
            //    new SnippetText() { Id = 1, CreatedDate = DateTime.Now, Text = "I like cats", User = user1 },
            //    new SnippetText() { Id = 2, CreatedDate = DateTime.Now, Text = "Wow, snippets are great", User = user2 },
            //    new SnippetText() { Id = 3, CreatedDate = DateTime.Now, Text = "Snippity snip snippet", User = user2 },
            //    new SnippetText() { Id = 4, CreatedDate = DateTime.Now, Text = "Snippetting is so fun", User = user2 },
            //    new SnippetText() { Id = 5, CreatedDate = DateTime.Now, Text = "Snipsnap", User = user1 },
            //    new SnippetText() { Id = 6, CreatedDate = DateTime.Now, Text = "So many snippets!", User = user2 },
            //    new SnippetText() { Id = 7, CreatedDate = DateTime.Now, Text = "Lorem ipsum dolor sit amet", User = user2 },
            //    new SnippetText() { Id = 8, CreatedDate = DateTime.Now, Text = "consectetur adipiscing elit", User = user4 },
            //    new SnippetText() { Id = 9, CreatedDate = DateTime.Now, Text = "sed do eiusmod tempor", User = user2 },
            //    new SnippetText() { Id = 10, CreatedDate = DateTime.Now, Text = "incididunt ut labore et dolore ", User = user2 },
            //    new SnippetText() { Id = 11, CreatedDate = DateTime.Now, Text = "magna aliqua", User = user3 },
            //    new SnippetText() { Id = 12, CreatedDate = DateTime.Now, Text = "Ut enim ad minim veniam", User = user2 },
            //    new SnippetText() { Id = 13, CreatedDate = DateTime.Now, Text = "quis nostrud exercitation ullamco laboris", User = user2 },
            //    new SnippetText() { Id = 14, CreatedDate = DateTime.Now, Text = "nisi ut aliquip ex ea commodo consequat", User = user2 },
            //    new SnippetText() { Id = 15, CreatedDate = DateTime.Now, Text = "Duis aute irure dolor", User = user2 }
            //    );

            //var snippet1 = context.Snippets.FirstOrDefault(x => x.Id == 1);
            //var snippet2 = context.Snippets.FirstOrDefault(x => x.Id == 2);
            //var snippet3 = context.Snippets.FirstOrDefault(x => x.Id == 3);
            //var snippet4 = context.Snippets.FirstOrDefault(x => x.Id == 4);
            //var snippet5 = context.Snippets.FirstOrDefault(x => x.Id == 5);
            //var snippet6 = context.Snippets.FirstOrDefault(x => x.Id == 6);
            //var snippet7 = context.Snippets.FirstOrDefault(x => x.Id == 7);
            //var snippet8 = context.Snippets.FirstOrDefault(x => x.Id == 8);
            //var snippet9 = context.Snippets.FirstOrDefault(x => x.Id == 9);
            //var snippet10 = context.Snippets.FirstOrDefault(x => x.Id == 10);
            //var snippet11 = context.Snippets.FirstOrDefault(x => x.Id == 11);
            //var snippet12 = context.Snippets.FirstOrDefault(x => x.Id == 12);
            //var snippet13 = context.Snippets.FirstOrDefault(x => x.Id == 13);
            //var snippet14 = context.Snippets.FirstOrDefault(x => x.Id == 14);
            //var snippet15 = context.Snippets.FirstOrDefault(x => x.Id == 15);

            //context.SnippetLikes.AddOrUpdate(x => x.Id,
            //    new SnippetLike() { Id = 1, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, LikedBy = user3, IsLiked = true },
            //    new SnippetLike() { Id = 2, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet2, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 3, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet3, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 4, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet4, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 5, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet5, LikedBy = user4, IsLiked = true },
            //    new SnippetLike() { Id = 6, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet6, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 7, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet7, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 8, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet8, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 9, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet9, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 10, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet10, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 11, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet11, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 12, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet12, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 13, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet13, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 14, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet14, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 15, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet15, LikedBy = user1, IsLiked = true },
            //    new SnippetLike() { Id = 16, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, LikedBy = user4, IsLiked = true },
            //    new SnippetLike() { Id = 17, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet2, LikedBy = user3, IsLiked = true },
            //    new SnippetLike() { Id = 18, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet3, LikedBy = user3, IsLiked = true },
            //    new SnippetLike() { Id = 19, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet4, LikedBy = user3, IsLiked = true },
            //    new SnippetLike() { Id = 20, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet5, LikedBy = user2, IsLiked = true },
            //    new SnippetLike() { Id = 21, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet6, LikedBy = user3, IsLiked = true },
            //    new SnippetLike() { Id = 22, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet7, LikedBy = user4, IsLiked = true },
            //    new SnippetLike() { Id = 23, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet8, LikedBy = user2, IsLiked = true },
            //    new SnippetLike() { Id = 24, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet9, LikedBy = user3, IsLiked = true },
            //    new SnippetLike() { Id = 25, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet10, LikedBy = user3, IsLiked = true }
            //    );

            //context.SnippetShares.AddOrUpdate(x => x.Id,
            //    new SnippetShare() { Id = 2, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 3, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 4, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 5, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 6, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 7, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 9, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 10, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 11, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 12, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 13, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true },
            //    new SnippetShare() { Id = 14, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = false },
            //    new SnippetShare() { Id = 15, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Snippet = snippet1, IsShared = true }
            //    );

            //base.Seed(context);
            //context.SaveChanges();
        }
    }
}
