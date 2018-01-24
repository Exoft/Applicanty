using System;
using System.Net;
using Applicanty.Core.Dto;
using Applicanty.Core.Responses;
using Applicanty.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class TechnologyController : Controller
    {
        ITechnologyService _technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var tecnologies = _technologyService.GetAll<TechnologyDto>();

                if (tecnologies == null)
                {
                    return BadRequest();
                }

                return Json(tecnologies);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}