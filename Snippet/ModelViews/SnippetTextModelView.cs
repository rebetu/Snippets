using Snippet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippet.ModelViews
{
    public class SnippetTextModelView
    {
        public int SnippetId { get; set; }
        public string Text { get; set; } 
        public string CreatedDate { get; set; }
        public int UserId { get; set; }

        public SnippetTextModelView(SnippetText snippet)
        {
            SnippetId = snippet.Id;
            Text = snippet.Text;
            CreatedDate = snippet.CreatedDate.ToShortDateString();
            UserId = snippet.User.Id;
        }
    }

    
}