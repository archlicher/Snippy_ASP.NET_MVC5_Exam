using System.Data.Entity;
using System.Web.WebPages;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Snippy.App.Models.BindingModels;
using Snippy.App.Models.ViewModels;
using Snippy.Models;

namespace Snippy.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Snippy.Data.UnitOfWork;

    public class SnippetsController : BaseController
    {
        public SnippetsController(ISnippyData data)
            : base(data)
        {
        }
        // GET: Snippets
        public ActionResult Index(int page = 1, int count = 5)
        {
            var snippets = this.Data.Snippets.All();
            var snippetCount = snippets.Count();
            snippets = snippets
                .Include(s => s.Labels)
                .OrderByDescending(s => s.CreationDate)
                .Skip((page - 1)*count)
                .Take(count);
            this.ViewBag.TotalPages = (int)(snippetCount + count - 1) / count;
            this.ViewBag.CurrentPage = page;
            var snippetsView = Mapper.Map<IEnumerable<ConciseSnippetViewModel>>(snippets);
            return View(snippetsView);
        }

        public ActionResult Details(int id)
        {
            var snippet = this.Data.Snippets.All()
                .Include(s => s.Labels)
                .Include(s => s.Comments)
                .FirstOrDefault(s => s.Id == id);
            var snippetDetails = Mapper.Map<DetailSnippetView>(snippet);

            return View(snippetDetails);
        }

        [Authorize]
        public ActionResult Create()
        {
            var languages = this.Data.Languages.All();
            this.ViewBag.Languages = new SelectList(languages, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SnippetBindingModel model,string language, string labels)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var snippet = new Snippet()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = this.Data.Users.Find(userId),
                    Language = this.Data.Languages.All().FirstOrDefault(l => l.Name == language),
                };
                if (!labels.IsEmpty())
                {
                    var allLabels = labels.Split(';');
                    foreach (var l in allLabels)
                    {
                        var labelToCheck = l.Trim();
                        var label = this.Data.Labels.All().FirstOrDefault(la => la.Text.ToLower() == labelToCheck.ToLower());
                        if (label == null)
                        {
                            var newLabel = new Label(){Text = l};
                            this.Data.Labels.Add(newLabel);
                            this.Data.SaveChanges();
                        }
                        label = this.Data.Labels.All().FirstOrDefault(la => la.Text == l);
                        snippet.Labels.Add(label);
                    }
                }
                this.Data.SaveChanges();
                return RedirectToAction("Details", "Snippets", new { id = snippet.Id });
            }
            return RedirectToAction("Index", "Users");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var languages = this.Data.Languages.All();
            this.ViewBag.Languages = new SelectList(languages, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SnippetBindingModel model, string labels)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var snippet = new Snippet()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = this.Data.Users.Find(userId),
                    Language = this.Data.Languages.All().FirstOrDefault(l => l.Id == model.LanguageId),
                };
                if (!labels.IsEmpty())
                {
                    var allLabels = labels.Split(';');
                    foreach (var l in allLabels)
                    {
                        var labelToCheck = l.Trim();
                        var label = this.Data.Labels.All().FirstOrDefault(la => la.Text.ToLower() == labelToCheck.ToLower());
                        if (label == null)
                        {
                            var newLabel = new Label() { Text = l };
                            this.Data.Labels.Add(newLabel);
                            this.Data.SaveChanges();
                        }
                        label = this.Data.Labels.All().FirstOrDefault(la => la.Text == l);
                        snippet.Labels.Add(label);
                    }
                }
                this.Data.SaveChanges();
                return RedirectToAction("Details", "Snippets", new { id = snippet.Id });
            }
            return RedirectToAction("Index", "Users");
        }
    }
}