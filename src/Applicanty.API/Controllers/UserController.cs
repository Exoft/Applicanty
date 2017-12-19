using Applicanty.API.Models;
using Applicanty.API.Models.Response;
using Applicanty.Data.Entity;
using Applicanty.Data.Services;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            try
            {
                // Require the user to have a confirmed email before they can log on.
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ViewBag.errorMessage = "You must have a confirmed email to log on.";

                        return BadRequest(new ErrorResponse("Email is not verified"));
                    }
                }
                
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                //var result = await _signInManager.PasswordSignInAsync(model.UserName, model.UserPassword, false, lockoutOnFailure: false);
                //switch (result)
                //{
                //    //    case SignInStatus.Success:
                //    //        return RedirectToLocal(returnUrl);
                //    //    case SignInStatus.LockedOut:
                //    //        return View("Lockout");
                //    //    case SignInStatus.RequiresVerification:
                //    //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                //    //    case SignInStatus.Failure:
                //    //    default:
                //    //        ModelState.AddModelError("", "Invalid login attempt.");
                //    //        return View(model);
                //}

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return Ok();

                BadRequest(result);
            }

            return BadRequest(model);
        }
    }
}