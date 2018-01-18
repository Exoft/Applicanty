using Applicanty.API.Helpers;
using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using Applicanty.Core.Responses;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Login([FromBody]UserLoginDto model)
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
        public async Task<IActionResult> Register([FromBody]UserRegisterDto model)
        {
            try
            {
                var user = new User { UserName = model.Email, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    string confirmationToken = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                    string confirmationLink = $"{Request.Headers["Origin"].ToString()}/confirmEmail?email{user.Email}&token={confirmationToken}";

                    await _emailSender.SendEmailAsync(user.Email, "ConfirmEmail", confirmationLink);

                    return Ok(true);
                }

                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(result.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost]
        public IActionResult ConfirmEmail([FromQuery]string email, [FromQuery]string token)
        {
            try
            {
                User user = _userManager.FindByEmailAsync(email).Result;
                IdentityResult result = _userManager.ConfirmEmailAsync(user, token).Result;

                if (result.Succeeded)
                    return Ok(true);

                throw new Exception("Exception occured during email confirmation.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
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