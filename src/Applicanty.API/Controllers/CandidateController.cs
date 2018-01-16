using Applicanty.API.Models.Response;
using Applicanty.Core.Entities;
using Applicanty.Core.Dto;
using Applicanty.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using Applicanty.API.Helpers;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class CandidateController : BaseController<Candidate>
    {
        ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper) :base(candidateService)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var candidate = _candidateService.GetOne<CandidateDetailsDto>(id);

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
        public IActionResult GetAll([FromQuery]int? skip, [FromQuery]int? take, [FromQuery]string property, [FromQuery]string sortBy)
        {
            try
            {
                var candidates = _candidateService.GetAll<CandidateDto>();
                var candidatesCount = candidates.Count();


                if (skip != null && take != null)
                    candidates = candidates.Skip((int)skip).Take((int)take);

                candidates = ListHelper<CandidateDto>.SortBy(candidates, property, sortBy);

                var response = new Response<CandidateDto>
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

        [HttpPut]
        public IActionResult Edit([FromBody]CandidateUpdateDto model)
        {
            try
            {
                var updatedModel = _candidateService.Update(model);

                return Ok(updatedModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}