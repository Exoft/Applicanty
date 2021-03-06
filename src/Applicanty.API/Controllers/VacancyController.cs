﻿using Applicanty.Core.Entities;
using Applicanty.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using Applicanty.Core.Responses;
using Microsoft.AspNetCore.Identity;
using Applicanty.Core.Services;
using Applicanty.API.Helpers;
using Applicanty.Core.Enums;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class VacancyController : BaseController<Vacancy>
    {
        private readonly IVacancyService _vacancyService;
        private readonly UserManager<User> _userManager;
        private readonly ITechnologyService _technologyService;
        private readonly ICommentService _commentService;

        public VacancyController(IVacancyService vacancyService,
            ICommentService commentService,
            UserManager<User> userManager,
            ITechnologyService technologyService) : base(vacancyService)
        {
            _vacancyService = vacancyService;
            _userManager = userManager;
            _technologyService = technologyService;
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                 var vacancy = _vacancyService.GetWithInclude<VacancyUpdateDto>(id, include => include.VacancyTechnologies);

                var vacancyWithComments = _commentService.GetByVacancy(vacancy);

                return Json(vacancyWithComments);
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
                var vacancies = _vacancyService.GetAll<VacancyGridDto>(item => item.StatusId == statusType).AsQueryable();
                var response = request.FilterAndSort(vacancies);

                return Json(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]VacancyCreateDto model)
        {
            try
            {
                var createdVacancy = _vacancyService.Create(model);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody]VacancyUpdateDto model)
        {
            try
            {
                var updatedModel = _vacancyService.Update(model);

                var createdComment = _commentService.Create(model);

                var updateModelWithComment = _commentService.GetByVacancy(updatedModel);

                return Ok(updateModelWithComment);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpGet("CountVacancyStageCandidates")]
        public IActionResult CountVacancyStageCandidates(int id)
        {
            try
            {
                var stageCandidates = _vacancyService.CountVacancyStageCandidates(id);

                return Json(stageCandidates);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost("AttachCandidate")]
        public IActionResult AttachCandidate([FromBody]VacancyCandidateDto model)
        {
            try
            {
                _vacancyService.AttachCandidate(model);

                return Json(model);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost("DetachCandidate")]
        public IActionResult DetachCandidate([FromBody]VacancyCandidateDto model)
        {
            try
            {
                _vacancyService.DetachCandidate(model);

                return Json(model);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost("ChangeCandidateStage")]
        public IActionResult ChangeCandidateStage([FromBody]VacancyCandidateDto model)
        {
            try
            {
                _vacancyService.ChangeCandidateStage(model);

                return Ok(true);
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
                var vacancy = _vacancyService.GetByTechnologyAndExperience(technologyIds, experience);

                return Json(vacancy);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpGet("GetByCandidate")]
        public IActionResult GetByCandidate(int candidateId)
        {
            try
            {
                var vacancy = _vacancyService.GetByCandidate(candidateId);

                return Json(vacancy);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}