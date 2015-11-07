namespace Snippy.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Snippy.Data.UnitOfWork;
    using Snippy.Models;

    public class BaseController : Controller
    {
        private ISnippyData data;
        private User userProfile;

        public BaseController(ISnippyData data)
        {
            this.Data = data;
        }

        public BaseController(ISnippyData data, User user)
            : this(data)
        {
            this.UserProfile = user;
        }

        public ISnippyData Data { get; private set; }

        public User UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}