using Applicanty.API.Models.Response;
using Applicanty.Data.Entity;
using Applicanty.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class CandidateController : Controller
    {
        ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var candidate = _candidateService.GetOne(id);

                if (candidate == null)
                {
                    return BadRequest();
                }

                return Json(candidate);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]int? skip, [FromQuery]int? take)
        {
            try
            {
                var candidatesCount = _candidateService.GetAll().Count();

                var candidates = _candidateService.GetAll();

                if (skip != null&& take != null)
                    candidates = _candidateService.GetAll().Skip((int)skip).Take((int)take);

                var response = new Response<Candidate>
                {
                    Result = candidates,
                    TotalCount = candidatesCount
                };
                return Json(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost("{model}")]
        public IActionResult Create(Candidate model)
        {
            try
            {
                _candidateService.Create(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPut("{model}")]
        public IActionResult Edit(Candidate model)
        {
            try
            {
                _candidateService.Create(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Archive(long id)
        {
            try
            {
                _candidateService.Archive(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}