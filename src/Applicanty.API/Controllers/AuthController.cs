using Applicanty.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Applicant.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            return Json(new { accessToken = $"this will became an accessToken for {loginModel.UserName} soon!!!" });
        }
    }
}
