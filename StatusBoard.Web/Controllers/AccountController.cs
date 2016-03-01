using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using StatusBoard.Core.Models.Identity;
using StatusBoard.Web.ViewModels;

namespace StatusBoard.Web.Controllers
{
    // Note that this is basically just stock code, I only changed a few things to remove things that I'm not using and didn't
    // feel like implementing (i.e. 2FA, OAuth (3rd party) login, etc).
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser, Guid> _userManager;

        public AccountController(UserManager<ApplicationUser, Guid> userManager)
        {
            _userManager = userManager;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AccountViewModel.LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    //why did MS think it was in the least bit smart to have a class called Constants
                    //in the top level AspNet.Identity namespace? That is why the below has additional qualification
                    ModelState.AddModelError("", Core.Constants.Validation.InvalidUserNameOrPassword);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountViewModel.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction(Core.Constants.Controller.Actions.Index, Core.Constants.Controller.Dashboard);
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction(Core.Constants.Controller.Actions.Login, Core.Constants.Controller.Account);
        }

        [HttpGet]
        public ActionResult Manage(string username)
        {
            var user = _userManager.FindByName(username)
            var manager = new AccountViewModel.ManageUserViewModel();
            manager.UserName = user.UserName;
            manager.Email = user.Email
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = _userManager.FindById(getGuid(User.Identity.GetUserId()));
            return user?.PasswordHash != null;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(Core.Constants.Controller.Actions.Index, Core.Constants.Controller.Dashboard);
            }
        }

       

        private Guid getGuid(string value)
        {
            var result = default(Guid);
            Guid.TryParse(value, out result);
            return result;
        }
        #endregion
    }
}