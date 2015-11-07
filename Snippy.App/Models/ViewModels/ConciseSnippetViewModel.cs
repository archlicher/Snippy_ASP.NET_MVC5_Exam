using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippy.App.Models.ViewModels
{
    public class ConciseSnippetViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<ConciseLabelViewModel> Labels { get; set; } 
    }
}