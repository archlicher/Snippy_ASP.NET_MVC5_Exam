using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snippy.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }

        [Required]
        public virtual User Author { get; set; }

        [Required]
        public virtual Snippet Snippet { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
