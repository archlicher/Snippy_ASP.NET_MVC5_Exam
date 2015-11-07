using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippy.App.Models.ViewModels
{
    public class LanguageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ConciseSnippetViewModel> Snippets { get; set; }
    }
}