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
    public class LabelsController : BaseController
    {
        public LabelsController(ISnippyData data)
            : base(data)
        {
        }
        // GET: Labels
        public ActionResult Details(int id)
        {
            var label = this.Data.Labels.All()
                .Include(l => l.Snippets)
                .FirstOrDefault(l => l.Id==id);
            var labelView = Mapper.Map<LabelDetailsViewModel>(label);
            return View(labelView);
        }
        
    }
}