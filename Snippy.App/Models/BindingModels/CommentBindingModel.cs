using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Snippy.App.Models.BindingModels
{
    public class CommentBindingModel
    {
        [Required]
        [MinLength(5), MaxLength(250)]
        public string Content { get; set; }
    }
}