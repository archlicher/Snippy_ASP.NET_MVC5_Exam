using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Snippy.App.Models.BindingModels;
using Snippy.App.Models.ViewModels;
using Snippy.Data.UnitOfWork;
using Snippy.Models;

namespace Snippy.App.Controllers
{
    [Authorize]
    public class CommentsController : BaseController
    {
        public CommentsController(ISnippyData data)
            : base(data)
        {
        }

        public CommentsController(ISnippyData data, User user)
            : base(data, user)
        {
        }

        // GET: Comments
        public ActionResult Create(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, CommentBindingModel model)
        {
            var snippet = this.Data.Snippets.Find(id);
            if (snippet == null)
            {
                TempData["messages_err"] = "Could not find snippet";
                return RedirectToAction("Index", "Home");
            }

            if (model != null && this.ModelState.IsValid)
            {
                var autorId = this.User.Identity.GetUserId();
                var comment = new Comment()
                {
                    Content = model.Content,
                    CreationDate = DateTime.Now,
                    Snippet = snippet,
                    Author = this.Data.Users.Find(autorId)
                };
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();
                TempData["messages_succ"] = "Successfully added comment";
            }
            return RedirectToAction("Details", "Snippets", new {id = id});
        }

        public ActionResult Details(int id)
        {
            var comment = this.Data.Comments.Find(id);
            var commentView = Mapper.Map<ConciseCommentViewModel>(comment);
            return View(commentView);
        }

        public ActionResult Delete(int id)
        {
            var comment = this.Data.Comments.Find(id);
            var snippetId = comment.Snippet.Id;
            this.Data.Comments.Remove(comment);
            this.Data.SaveChanges();

            return RedirectToAction("Details", "Snippets", new { id = snippetId });
        }
    }
}