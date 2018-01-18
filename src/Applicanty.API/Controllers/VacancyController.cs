using Applicanty.Core.Entities;
using Applicanty.Core.Dto;
using Applicanty.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using Applicanty.API.Helpers;
using Applicanty.Core.Responses;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Applicanty.API.Controllers
{
    [Route("[controller]")]
    public class VacancyController : BaseController<Vacancy>
    {
        private readonly IVacancyService _vacancyService;
        private readonly UserManager<User> _userManager;


        public VacancyController(IVacancyService vacancyService,
            UserManager<User> userManager) :base(vacancyService)
        {
            _vacancyService = vacancyService;
            _userManager = userManager;
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
        public IActionResult GetAll([FromQuery]int? skip, [FromQuery]int? take, [FromQuery]string property, [FromQuery]string sortBy)
        {
            try
            {
                var vacanciesCount = _vacancyService.GetAll<VacancyGridDto>().Count();
                var vacancies = _vacancyService.GetAll<VacancyGridDto>();

                if (skip != null && take != null)
                {
                    vacancies = _vacancyService.GetAll<VacancyGridDto>().Skip((int)skip).Take((int)take);
                }

                vacancies = ListHelper<VacancyGridDto>.SortBy(vacancies, property, sortBy);

                var response = new Response<VacancyGridDto>
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]VacancyCreateDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                model.CreatedBy = user.Id;
                model.ModifiedBy = user.Id;

                model.CreatedAt = DateTime.Now;
                model.ModifiedAt = DateTime.Now;

                _vacancyService.Create(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]VacancyUpdateDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                model.ModifiedAt = DateTime.Now;
                model.ModifiedBy = user.Id;

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