using Snippet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippet.ModelViews
{
    public class SnippetLikeModelView

    {
        public int SnippetLikeId { get; set; }
        public int SnippetId { get; set; }
        public string Text { get; set; } 
        public string CreatedDate { get; set; }
        public string LikedDate { get; set; }
        public int AuthorId { get; set; }
        public string AuthorEmail { get; set; }
        public int LikedById { get; set; }
        public string LikedByEmail { get; set; }

        public SnippetLikeModelView(SnippetLike snippetLike)
        {
            SnippetLikeId = snippetLike.Id;
            SnippetId = snippetLike.Snippet.Id;
            Text = snippetLike.Snippet.Text;
            CreatedDate = snippetLike.Snippet.CreatedDate.ToLongDateString();
            LikedDate = snippetLike.LastModifiedDate.ToLongDateString();
            AuthorId = snippetLike.Snippet.User.Id;
            AuthorEmail = snippetLike.Snippet.User.Email;
            LikedById = snippetLike.LikedBy.Id;
            LikedByEmail = snippetLike.LikedBy.Email;
        }
    }

    
}