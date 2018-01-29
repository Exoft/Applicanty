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
using System.Threading.Tasks;
using Applicanty.Core.Services;

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
        public IActionResult GetAll([FromQuery]GridRequest request)
        {
            try
            {
                var candidates = _candidateService.GetAll<CandidateGridDto>().AsQueryable();

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
        public async Task<IActionResult> Create([FromBody]CandidateCreateUpdateDto model)
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
        public async Task<IActionResult> Edit([FromBody]CandidateCreateUpdateDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var updatedModel = _candidateService.Update(model);

                return Ok(updatedModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }

        [HttpGet("GetByVacansy")]
        public IActionResult GetByVacansy([FromQuery]int idVacancy, [FromQuery]int idStage)
        {
            try
            {
                return Json(_candidateService.GetCandidatesByVacancyStage(idVacancy, idStage));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}