using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippy.App.Models.ViewModels
{
    public class ConciseLabelViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int Snippets { get; set; }
    }
}