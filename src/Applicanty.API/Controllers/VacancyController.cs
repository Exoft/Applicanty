using Applicanty.API.Models.Response;
using Applicanty.Core.Entities;
using Applicanty.Core.Dto;
using Applicanty.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class VacancyController : Controller
    {
        IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var vacancy = _vacancyService.GetOne<VacancyDetailsDTO>(id);

                return Json(vacancy);
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
                var vacanciesCount = _vacancyService.GetAll<VacancyDTO>().Count();

                var vacancies = _vacancyService.GetAll<VacancyDTO>();

                if (skip != null && take != null)
                    vacancies = _vacancyService.GetAll<VacancyDTO>().Skip((int)skip).Take((int)take);

                var response = new Response<VacancyDTO>
                {
                    Result = vacancies,
                    TotalCount = vacanciesCount
                };

                return Json(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPost("{model}")]
        public IActionResult Create(Vacancy model)
        {
            try
            {
                _vacancyService.Create(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPut("{model}")]
        public IActionResult Edit(Vacancy model)
        {
            try
            {
                _vacancyService.Create(model);

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
                _vacancyService.Archive(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}