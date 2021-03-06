﻿using Applicanty.Core.Entities;
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
                var candidate = _candidateService.GetWithInclude<CandidateCreateUpdateDto>(id, include => include.CandidateTechnologies);

                if (candidate == null)
                    return BadRequest("Candidate not found.");

                return Json(candidate);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll([FromBody]GridHelper request, StatusType statusType)
        {
            try
            {
                var candidates = _candidateService.GetAll<CandidateGridDto>(item => item.StatusId == statusType).AsQueryable();
                var response = request.FilterAndSort(candidates);

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

        [HttpGet("GetByVacancyAndStage")]
        public IActionResult GetByVacancyAndStage([FromQuery]int vacancyId, [FromQuery]int stageId)
        {
            try
            {
                var candidates = _candidateService.GetByVacancy(vacancyId, stageId);

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

        [HttpGet("GetByVacancy")]
        public IActionResult GetByVacancy([FromQuery]int vacancyId)
        {
            try
            {
                var candidates = _candidateService.GetByVacancy(vacancyId);

                var response = new Response<CandidateVacancyAttachDto>
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

        [HttpPost("GetByTechnologyAndExperience")]
        public IActionResult GetByTechnologyAndExperience([FromBody]int[] technologyIds, [FromQuery]Experience experience)
        {
            try
            {
                var vacancy = _candidateService.GetByTechnologyAndExperience(technologyIds, experience);

                return Json(vacancy);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}

