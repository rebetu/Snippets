using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Snippet.Models
{
    [Table("SnippetLike", Schema = "snippet")]
    public class SnippetLike
    {
        public SnippetLike()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsLiked { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public virtual SnippetText Snippet { get; set; }

        public virtual AppUser LikedBy { get; set; }
    }
}
