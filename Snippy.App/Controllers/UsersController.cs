using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Snippy.App.Models.ViewModels;
using Snippy.Data.UnitOfWork;
using Snippy.Models;

namespace Snippy.App.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(ISnippyData data)
            : base(data)
        {
        }

        public UsersController(ISnippyData data, User user)
            : base(data, user)
        {
        }
        // GET: Users
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var snippets = this.Data.Snippets.All()
                .Where(s => s.Author.Id == userId)
                .Include(s => s.Labels)
                .OrderByDescending(s => s.CreationDate);
            var snippetsView = Mapper.Map<IEnumerable<ConciseSnippetViewModel>>(snippets);
            return View(snippetsView);
        }
    }
}