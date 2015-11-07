using System.ComponentModel.DataAnnotations;

namespace Snippy.Models
{
    using System.Collections.Generic;

    public class Language
    {
        public Language()
        {
            this.Snippets = new HashSet<Snippet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Snippet> Snippets { get; set; } 
    }
}
