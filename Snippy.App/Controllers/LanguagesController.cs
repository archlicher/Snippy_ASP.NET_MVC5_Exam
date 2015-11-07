using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Snippy.App.Models.ViewModels;
using Snippy.Data.UnitOfWork;

namespace Snippy.App.Controllers
{
    public class LanguagesController : BaseController
    {
        public LanguagesController(ISnippyData data)
            : base(data)
        {
        }
        // GET: Languages
        public ActionResult Details(int id)
        {
            var language = this.Data.Languages.All().Include(l => l.Snippets).FirstOrDefault(l => l.Id == id);
            var languageDisplay = Mapper.Map<LanguageViewModel>(language);
            return View(languageDisplay);
        }
    }
}