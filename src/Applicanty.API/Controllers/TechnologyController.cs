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

        [HttpPost]
        public IActionResult Create([FromBody]TechnologyDto model)
        {
            try
            {
                _technologyService.Create(model);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody]TechnologyDto model)
        {
            try
            {
                var updatedModel = _technologyService.Update(model);

                return Json(updatedModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]int id)
        {
            try
            {
                _technologyService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}