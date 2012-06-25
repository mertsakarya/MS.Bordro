﻿using System;
using System.Web;
using System.Web.Mvc;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Infrastructure.Exceptions.Web;

namespace MS.Bordro.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true,
       AllowMultiple = false)]
    public class BordroFilterAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public BordroFilterAttribute() { 
            ExceptionView = "BordroError";
            IsAuthenticated = false;
            MustHaveGender = false;
            MustHaveProfile = false;
        }

        /// <summary>
        /// Default value is false
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Default value is false
        /// </summary>
        public bool MustHaveGender { get; set; }

        /// <summary>
        /// Default value is false
        /// </summary>
        public bool MustHaveProfile { get; set; }

        /// <summary>
        /// Default view is BordroError
        /// </summary>
        public string ExceptionView { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var user = filterContext.Controller.ViewBag.BordroUser as User;
            var actionName = (string)filterContext.RouteData.Values["action"];
            if (IsAuthenticated && !filterContext.HttpContext.User.Identity.IsAuthenticated)
                throw new BordroNotAllowedException(user, controllerName + "." + actionName + " [NotAuthenticated]");

        }

        public void OnException(ExceptionContext filterContext)
        {
            
            if (filterContext == null) {
                throw new ArgumentNullException("filterContext");
            }

            // If custom errors are disabled, we need to let the normal ASP.NET exception handler
            // execute so that the user can see useful debugging information.
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled) {
                return;
            }

            Exception exception = filterContext.Exception;

            // If this is not an HTTP 500 (for example, if somebody throws an HTTP 404 from an action method),
            // ignore it.
            if (new HttpException(null, exception).GetHttpCode() != 500) {
                return;
            }

            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            filterContext.Result = new ViewResult {
                ViewName = ExceptionView,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            // Certain versions of IIS will sometimes use their own error page when
            // they detect a server error. Setting this property indicates that we
            // want it to try to render ASP.NET MVC's error page instead.
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
