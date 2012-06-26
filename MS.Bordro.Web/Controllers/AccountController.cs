using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Web.Models;
using MembershipCreateStatus = MS.Bordro.Enumerations.MembershipCreateStatus;

namespace MS.Bordro.Web.Controllers
{

    [Authorize]
    public class AccountController : BordroController
    {
        public AccountController(IResourceService resourceService, IUserService userService)
            : base(resourceService, userService) {}

        [AllowAnonymous]
        public ActionResult Login() { return ContextDependentView(null, "Login"); }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult JsonLogin(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid) {
                if (UserService.ValidateUser(model.UserName, model.Password)) {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return Json(new {success = true, redirect = returnUrl});
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }
            return Json(new {errors = GetErrorsFromModelState()});
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid) {
                if (UserService.ValidateUser(model.UserName, model.Password)) {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl)) {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult LoginWithId(string key)
        {
            long uid;
            Guid guid;
            User model;
            if (long.TryParse(key, out uid)) {
                model = UserService.GetUser(uid);
            } else if (Guid.TryParse(key, out guid)) {
                model = UserService.GetUser(guid);
            } else {
                model = UserService.GetUser(key);
            }
            if (model != null) {
                if (UserService.ValidateUser(model.UserName, model.Password)) {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View("Login", new LoginModel());
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["AccessToken"] = null;
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return ContextDependentView(null, "Register");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult JsonRegister(RegisterModel model)
        {
            if (ModelState.IsValid) {
                MembershipCreateStatus createStatus;
                UserService.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);
                if (createStatus == MembershipCreateStatus.Success) {
                    FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                    return Json(new {success = true});
                }
                ModelState.AddModelError("", ErrorCodeToString(createStatus));
            }
            return Json(new {errors = GetErrorsFromModelState()});
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid) {
                MembershipCreateStatus createStatus;
                UserService.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);
                if (createStatus == MembershipCreateStatus.Success) {
                    FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", ErrorCodeToString(createStatus));
            }
            return View(model);
        }

        public ActionResult ChangePassword() { return View(); }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid) {
                bool changePasswordSucceeded;
                try {
                    changePasswordSucceeded = UserService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                } catch (Exception) {
                    changePasswordSucceeded = false;
                }
                if (changePasswordSucceeded) {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            }
            return View(model);
        }

        public ActionResult ChangePasswordSuccess() { return View(); }

        private ActionResult ContextDependentView(object model = null, string viewName = "")
        {
            var actionName = ControllerContext.RouteData.GetRequiredString("action");
            if (Request.QueryString["content"] != null) {
                ViewBag.FormAction = "Json" + actionName;
                return PartialView(viewName, model);
            }
            ViewBag.FormAction = actionName;
            return View(viewName, model);
        }

        private IEnumerable<string> GetErrorsFromModelState() { return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage)); }

        #region Status Codes
        private string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus) {
                case MembershipCreateStatus.DuplicateUserName:
                    return ResourceService.ResourceValue("MembershipCreateStatus." + createStatus);

                case MembershipCreateStatus.DuplicateEmail:
                    return ResourceService.ResourceValue("MembershipCreateStatus." + createStatus);

                case MembershipCreateStatus.InvalidPassword:
                    return ResourceService.ResourceValue("MembershipCreateStatus." + createStatus);

                case MembershipCreateStatus.InvalidEmail:
                    return ResourceService.ResourceValue("MembershipCreateStatus." + createStatus);

                case MembershipCreateStatus.InvalidAnswer:
                    return ResourceService.ResourceValue("MembershipCreateStatus." + createStatus);

                case MembershipCreateStatus.InvalidQuestion:
                    return ResourceService.ResourceValue("MembershipCreateStatus." + createStatus);

                case MembershipCreateStatus.InvalidUserName:
                    return ResourceService.ResourceValue("MembershipCreateStatus." + createStatus);

                case MembershipCreateStatus.ProviderError:
                    return ResourceService.ResourceValue("MembershipCreateStatus." + createStatus);

                case MembershipCreateStatus.UserRejected:
                    return ResourceService.ResourceValue("MembershipCreateStatus." + createStatus);

                default:
                    return ResourceService.ResourceValue("MembershipCreateStatus.Default");
            }
        }
        #endregion
    }
}
