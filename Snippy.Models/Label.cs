namespace Snippy.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Label
    {
        public Label()
        {
            this.Snippets = new HashSet<Snippet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public ICollection<Snippet> Snippets { get; set; } 
    }
}
