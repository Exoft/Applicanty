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
    public class VacancyController : BaseController<Vacancy>
    {
        IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService):base(vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var vacancy = _vacancyService.GetOne<VacancyDetailsDto>(id);

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
                var vacanciesCount = _vacancyService.GetAll<VacancyDto>().Count();

                var vacancies = _vacancyService.GetAll<VacancyDto>();

                if (skip != null && take != null)
                    vacancies = _vacancyService.GetAll<VacancyDto>().Skip((int)skip).Take((int)take);

                var response = new Response<VacancyDto>
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

        [HttpPut]
        public IActionResult Edit([FromBody]VacancyUpdateDto model)
        {
            try
            {
               var updatedModel = _vacancyService.Update(model);

                return Ok(updatedModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}