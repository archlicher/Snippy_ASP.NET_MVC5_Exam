using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snippy.Models;

namespace Snippy.App.Models.ViewModels
{
    public class DetailSnippetView
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public string Author { get; set; }

        public DateTime CreationDate { get; set; }

        public Language Language { get; set; }

        public ICollection<ConciseLabelViewModel> Labels { get; set; }

        public ICollection<ConciseCommentViewModel> Comments { get; set; } 
    }
}