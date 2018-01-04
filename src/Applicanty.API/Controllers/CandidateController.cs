using Applicanty.API.Models.Response;
using Applicanty.Core.Model;
using Applicanty.DTO.DtoModel;
using Applicanty.Services.Abstract;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var candidate = _candidateService.GetOne<CandidateDetailsDTO>(id);

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
                var candidates = _candidateService.GetAll<CandidateDTO>();
                var candidatesCount = candidates.Count();


                if (skip != null&& take != null)
                    candidates = candidates.Skip((int)skip).Take((int)take);

                var response = new Response<CandidateDTO>
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
        public IActionResult Archive(int id)
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