namespace Snippy.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Snippy.App.Models.ViewModels;
    using Snippy.Data.UnitOfWork;

    public class HomeController : BaseController
    {
        public HomeController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var latestSnippets = this.Data.Snippets.All()
                .Include(s => s.Labels)
                .OrderByDescending(s => s.CreationDate)
                .Take(5);
            var latestComments = this.Data.Comments.All()
                .OrderByDescending(c => c.CreationDate)
                .Take(5);
            var topLabels = this.Data.Labels.All()
                .Include(c => c.Snippets)
                .OrderByDescending(l => l.Snippets.Count)
                .Take(5);

            var homeView = new HomePageViewModel()
            {
                Comments = Mapper.Map<IEnumerable<ConciseCommentViewModel>>(latestComments),
                Labels = Mapper.Map<IEnumerable<ConciseLabelViewModel>>(topLabels),
                Snippets = Mapper.Map<IEnumerable<ConciseSnippetViewModel>>(latestSnippets)
            };

            return View(homeView);
        }
    }
}