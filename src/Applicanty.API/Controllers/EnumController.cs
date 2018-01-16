using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applicanty.Core.Enums;
using Applicanty.API.Helpers;
using Applicanty.API.Models;
using Applicanty.API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class EnumController : Controller
    {
        [HttpGet("{enumName}")]
        public IActionResult Get(string enumName)
        {
            try
            {
                var enumMembers = new List<EnumItem>();
                var assembly = Assembly.Load($"Applicanty.Core");
                var enumType = assembly.GetType($"Applicanty.Core.Enums.{enumName}");

                foreach (var item in Enum.GetValues(enumType))
                {
                    enumMembers.Add(new EnumItem
                    {
                        Value = (int)item,
                        Name = EnumHelper.GetDescriptionAttributeValue(enumType, item.ToString())
                    });
                }

                return Json(new Response<EnumItem> { Result = enumMembers.AsEnumerable() });
            }
            catch (Exception ex)
            {
                return Json(new ErrorResponse(ex));
            }
        }
    }
}