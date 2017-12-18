using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applicanty.API.Models;
using Applicanty.Data.Entity;
using Applicanty.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Applicanty.API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        //private readonly UserSerices _userSerices;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
            //_userSerices = userSerices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userManager.Users.ToList();
            return Json(users);
        }

        [HttpPost("/user/register/")]
        public async Task<IActionResult> Register(RegisterModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = new User {UserName = model.Email, Email = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok();
                }
                BadRequest(result);
            }

           return BadRequest(model);
        }
    }
}