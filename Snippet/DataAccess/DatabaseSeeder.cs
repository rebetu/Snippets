using Snippet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippet.DataAccess
{
    internal class DatabaseSeeder
    {
        public static void Seed(MainContext context)
        {
            var user1 = new AppUser()
            {
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Email = "user1@email.com"
            };
            context.AppUsers.Add(user1);
            
            context.AppUsers.Add(new AppUser { CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Email = "user2@email.com" });

            var snippet1 = context.Snippets.Add(new SnippetText { CreatedDate = DateTime.Now, Text = "I like cats" });
            user1.Snippets.Add(snippet1);

            context.AppUsers.Add(new AppUser { CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Email = "user3@email.com" });
            context.AppUsers.Add(new AppUser { CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Email = "user4@email.com" });
        }
    }
}