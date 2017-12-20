﻿using Applicanty.API.Models.Response;
using Applicanty.Data.Entity;
using Applicanty.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Get(long id)
        {
            try
            {
                var vacancies = _vacancyService.GetOne(id);

                return Json(vacancies);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var vacancy = _vacancyService.GetAll();

                var response = new Response<Vacancy>
                {
                    Result = vacancy,
                    TotalCount = vacancy.Count()
                };

                return Json(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
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
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
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
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Archive(long id)
        {
            try
            {
                _vacancyService.Archive(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
            }
        }
    }
}