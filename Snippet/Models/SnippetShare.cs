using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Snippet.Models
{
    [Table("SnippetShare", Schema = "snippet")]
    public class SnippetShare
    {
        public SnippetShare()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsShared { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public virtual SnippetText Snippet { get; set; }

        public virtual AppUser SharedBy { get; set; }
    }
}
