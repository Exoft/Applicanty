using Applicanty.API.Models;
using Applicanty.API.Models.Response;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Applicanty.Core.Model;
using Applicanty.API.Helpers;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;

        public UserController(UserManager<User> userManager,
            IConfiguration configuration,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    if (user.EmailConfirmed)
                    {
                        var tokenResponse = await RequestTokenAsync(model.Email, model.Password);

                        if (tokenResponse.HttpStatusCode == HttpStatusCode.OK)
                            return Ok(tokenResponse.Raw);

                        throw new Exception($"{tokenResponse.Error}{Environment.NewLine}{tokenResponse.ErrorDescription}");
                    }
                    else
                    {
                        throw new Exception("Confirm Email Address.");
                    }
                }

                return StatusCode((int)HttpStatusCode.Forbidden);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            try
            {
                var user = new User { UserName = model.Email, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    string confirmationToken = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;

                    string confirmationLink = Url.Action("ConfirmEmail",
                      "User", new
                      {
                          userid = user.Id,
                          token = confirmationToken
                      },
                       protocol: HttpContext.Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "ConfirmEmail", confirmationLink);

                    return Ok();
                }

                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(result.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost("secure")]
        public async Task<IActionResult> Secure([FromBody]string token)
        {
            var discoveryClient = new DiscoveryClient(_configuration["ApiBaseUrl"]);
            var doc = await discoveryClient.GetAsync();

            var introspectionClient = new IntrospectionClient(doc.IntrospectionEndpoint, "applicantyAPI", "secret");
            var response = await introspectionClient.SendAsync(new IntrospectionRequest { Token = token });

            if (response.IsError)
                return Ok(false);

            return Ok(response.IsActive);
        }

        [HttpGet]
        public IActionResult ConfirmEmail(string userid, string token)
        {
            User user = _userManager.FindByIdAsync(userid).Result;
            IdentityResult result = _userManager.
                        ConfirmEmailAsync(user, token).Result;
            if (result.Succeeded)
            {
                return Ok("Success");
            }
            else
            {
                return Ok("Error");
            }
        }

        private async Task<TokenResponse> RequestTokenAsync(string username, string password)
        {
            var discoveryClient = new DiscoveryClient(_configuration["ApiBaseUrl"]);
            var doc = await discoveryClient.GetAsync();

            var tokenClient = new TokenClient(doc.TokenEndpoint, "ro.client", "secret");
            var tokenResponse = await tokenClient.RequestAsync(new Dictionary<string, string>
            {
                {"client_id", "ro.client"},
                {"client_secret", "secret"},
                {"grant_type", "password"},
                {"username", username},
                {"password",password}
            });

            return tokenResponse;
        }
    }
}