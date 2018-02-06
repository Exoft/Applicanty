using Applicanty.Core.Entities;
using Applicanty.Core.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using Applicanty.API.Helpers;
using Applicanty.Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Applicanty.Core.Services;
using Applicanty.Core.Enums;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class CandidateController : BaseController<Candidate>
    {
        ICandidateService _candidateService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CandidateController(UserManager<User> userManager,
            ICandidateService candidateService,
            IMapper mapper) : base(candidateService)
        {
            _candidateService = candidateService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var candidate = _candidateService.GetOne<CandidateDetailsDto>(id);

                if (candidate == null)
                    return BadRequest("Candidate not found.");

                return Json(candidate);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]GridRequest request, StatusType statusType)
        {
            try
            {
                var candidates = _candidateService.GetAll<CandidateGridDto>(item => item.StatusId == statusType).AsQueryable();

                var response = new Response<CandidateGridDto>
                {
                    Result = request.Sort(candidates),
                    TotalCount = candidates.Count()
                };

                return Json(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]CandidateCreateUpdateDto model)
        {
            try
            {
                _candidateService.Create(model);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody]CandidateCreateUpdateDto model)
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

        [HttpGet("GetByVacancy")]
        public IActionResult GetByVacancy([FromQuery]int vacancyId, [FromQuery]int stageId)
        {
            try
            {
                var candidates = _candidateService.GetCandidatesByVacancyStage(vacancyId, stageId);

                var response = new Response<CandidateGridDto>
                {
                    Result = candidates,
                    TotalCount = candidates.Count()
                };

                return Json(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}