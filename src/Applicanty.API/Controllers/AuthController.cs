using Applicanty.API.Models;
using Applicanty.API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Applicant.API.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            try
            {
                using (var httpClient = new HttpClient(new HttpClientHandler()))
                {
                    httpClient.BaseAddress = new Uri($"http://localhost:8000");

                    var requestUri = "connect/token";
                    
                    var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

                    Dictionary<string, string> pairs = new Dictionary<string, string>
                    {
                        { "client_id", "ro.client" },
                        { "client_secret", "secret" },
                        { "grant_type", "password" },
                        { "username", loginModel.UserName },
                        { "password", loginModel.UserPassword }
                    };

                    FormUrlEncodedContent formContent = new FormUrlEncodedContent(pairs);

                    var httpResponse = await httpClient.PostAsync(requestUri, formContent);
                    
                    return Ok(await httpResponse.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
            }
        }
    }
}
