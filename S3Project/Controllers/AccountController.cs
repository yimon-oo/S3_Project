using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S3Project.Entities;
using S3Project.IRepository;
using S3Project.Models;
using System.Security.Claims;

namespace S3Project.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository userRepo;
        public AccountController(IUserRepository _userRepo)
        {
            this.userRepo = _userRepo;
        }
        //[AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string returnUrl)
        {
            //if (ModelState.IsValid)
            //{
                var user = userRepo.FindByUserName(model.UserName);
                if (user != null)
                {
                return RedirectToAction("Index", "VisitorInfo");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            //}

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
