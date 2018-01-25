using Applicanty.Core.Entities;
using Applicanty.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using Applicanty.Core.Responses;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Applicanty.Core.Services;
using Applicanty.API.Helpers;

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
        public IActionResult GetAll([FromQuery]ClarityGridRequest request)
        {
            try
            {
                var vacancies = _vacancyService.GetAll<VacancyGridDto>().AsQueryable();

                var response = new Response<VacancyGridDto>
                {
                    Result = request.Sort(vacancies),
                    TotalCount = vacancies.Count()
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

                var updatedModel = _vacancyService.Update(model);

                return Ok(updatedModel);
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
    }
}