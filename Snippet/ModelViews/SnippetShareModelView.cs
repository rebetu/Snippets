using Snippet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippet.ModelViews
{
    public class SnippetShareModelView

    {
        public int SnippetShareId { get; set; }
        public int SnippetId { get; set; }
        public string Text { get; set; } 
        public string CreatedDate { get; set; }
        public string SharedDate { get; set; }
        public int AuthorId { get; set; }
        public string AuthorEmail { get; set; }
        public int SharedById { get; set; }
        public string SharedByEmail { get; set; }

        public SnippetShareModelView(SnippetShare snippetShare)
        {
            SnippetShareId = snippetShare.Id;
            SnippetId = snippetShare.Snippet.Id;
            Text = snippetShare.Snippet.Text;
            CreatedDate = snippetShare.Snippet.CreatedDate.ToLongDateString();
            SharedDate = snippetShare.LastModifiedDate.ToLongDateString();
            AuthorId = snippetShare.Snippet.User.Id;
            AuthorEmail = snippetShare.Snippet.User.Email;
            SharedById = snippetShare.SharedBy.Id;
            SharedByEmail = snippetShare.SharedBy.Email;
        }
    }

    
}