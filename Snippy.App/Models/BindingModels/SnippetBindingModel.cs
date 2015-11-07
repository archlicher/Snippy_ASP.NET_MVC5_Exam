using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Snippy.Models;

namespace Snippy.App.Models.BindingModels
{
    public class SnippetBindingModel
    {
        [Required]
        [MinLength(5), MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MinLength(5), MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [MinLength(5), MaxLength(1000)]
        public string Code { get; set; }

        public int LanguageId { get; set; }
    }
}