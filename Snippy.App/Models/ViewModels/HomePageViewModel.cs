using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippy.App.Models.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<ConciseLabelViewModel> Labels { get; set; }

        public IEnumerable<ConciseSnippetViewModel> Snippets { get; set; }

        public IEnumerable<ConciseCommentViewModel> Comments { get; set; }
    }
}