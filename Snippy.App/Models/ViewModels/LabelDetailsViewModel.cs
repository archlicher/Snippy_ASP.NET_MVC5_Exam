using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippy.App.Models.ViewModels
{
    public class LabelDetailsViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public IEnumerable<ConciseSnippetViewModel> Snippets { get; set; }
    }
}