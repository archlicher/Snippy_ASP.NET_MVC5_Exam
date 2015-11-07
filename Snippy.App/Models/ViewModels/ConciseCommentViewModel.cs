using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippy.App.Models.ViewModels
{
    public class ConciseCommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public ConciseSnippetViewModel Snippet { get; set; }

        public DateTime CreationDate { get; set; }
    }
}