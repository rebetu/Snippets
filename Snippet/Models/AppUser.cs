using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Snippet.Models
{
    [Table("AppUser", Schema = "snippet")]
    public class AppUser
    {
        public AppUser()
        {
            Snippets = new List<SnippetText>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public ICollection<SnippetText> Snippets { get; set; }
    }
}
