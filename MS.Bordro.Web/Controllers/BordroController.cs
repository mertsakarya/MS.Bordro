using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Services;
using MS.Katusha.Web.Helpers;

namespace MS.Bordro.Web.Controllers
{
    public class BordroController : Controller
    {
        public User KatushaUser { get; set; }

        protected IUserService UserService { get; set; }
        protected IResourceService ResourceService { get; set; }

        public BordroController(IResourceService resourceService, IUserService userService)
        {
            ResourceService = resourceService;
            UserService = userService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            KatushaUser = (User.Identity.IsAuthenticated) ? UserService.GetUser(User.Identity.Name) : null;
            ViewBag.KatushaUser = KatushaUser;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            #region internationalization
            //// Is it View ?
            //var view = filterContext.Result as ViewResultBase;
            //if (view == null) // if not exit
            //    return;

            //string cultureName = Thread.CurrentThread.CurrentCulture.Name; // e.g. "en-US" // filterContext.HttpContext.Request.UserLanguages[0]; // needs validation return "en-us" as default            

            //// Is it default culture? exit
            //if (cultureName == CultureHelper.GetDefaultCulture())
            //    return;

            //// Are views implemented separately for this culture?  if not exit
            //bool viewImplemented = CultureHelper.IsViewSeparate(cultureName);
            //if (viewImplemented == false)
            //    return;

            //string viewName = view.ViewName;

            //int i;

            //if (string.IsNullOrEmpty(viewName))
            //    viewName = filterContext.RouteData.Values["action"] + "." + cultureName; // Index.en-US
            //else if ((i = viewName.IndexOf('.')) > 0) {
            //    // contains . like "Index.cshtml"                
            //    viewName = viewName.Substring(0, i + 1) + cultureName + viewName.Substring(i);
            //} else
            //    viewName += "." + cultureName; // e.g. "Index" ==> "Index.en-Us"

            //view.ViewName = viewName;

            //filterContext.Controller.ViewBag._culture = "." + cultureName;
            #endregion
            
            base.OnActionExecuted(filterContext);
        }

        protected override void ExecuteCore()
        {
            var cultureCookie = Request.Cookies["_culture"];
            var cultureName = cultureCookie == null ? (Request.UserLanguages != null ? Request.UserLanguages[0] : null) : cultureCookie.Value;
            cultureName = CultureHelper.GetValidCulture(cultureName);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);

            base.ExecuteCore();
        }
    }
}
