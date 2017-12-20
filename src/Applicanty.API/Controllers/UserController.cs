using Applicanty.API.Models;
using Applicanty.API.Models.Response;
using Applicanty.Data.Entity;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            try
            {
                var tokenResponse = await RequestTokenAsync(model.Email, model.Password);

                if (tokenResponse.HttpStatusCode == HttpStatusCode.OK)
                    return Ok(tokenResponse.Raw);

                if (tokenResponse.Error.Contains("invalid_grant"))
                   return StatusCode((int)HttpStatusCode.Forbidden);

                throw new Exception($"{tokenResponse.Error}{Environment.NewLine}{tokenResponse.ErrorDescription}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
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
                    var tokenResponse = await RequestTokenAsync(model.Email, model.Password);
                    return Ok(tokenResponse.Raw);
                }

                StringBuilder errors = new StringBuilder();

                foreach (var item in result.Errors)
                    errors.AppendLine($"{item}");

                throw new Exception(errors.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
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