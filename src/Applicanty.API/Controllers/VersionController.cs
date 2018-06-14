using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class VersionController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var appVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

            return Ok(new { version = appVersion });
        }
    }
}