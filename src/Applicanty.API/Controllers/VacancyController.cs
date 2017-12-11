using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Applicanty.Data.Services;
using Applicanty.Data.Entity;

namespace Applicanty.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Vacancy")]
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
            var vacancy = _vacancyService.GetOne(id);
            if (vacancy == null)
            {
                return BadRequest();
            }
            return Json(vacancy);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var vacancy = _vacancyService.GetAll();
            return Json(vacancy);
        }

        [HttpPost("{model}")]
        public IActionResult Create(Vacancy model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            _vacancyService.Create(model);
            return Ok();
        }

        [HttpPost("{model}")]
        public IActionResult Edit(Vacancy model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            _vacancyService.Create(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Archive(long id)
        {
            _vacancyService.Archive(id);
            return Ok(); 
        }
    }
}