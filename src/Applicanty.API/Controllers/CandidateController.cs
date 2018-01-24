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
        public IActionResult GetAll([FromQuery]int? skip, [FromQuery]int? take, [FromQuery]string property, [FromQuery]string sortBy)
        {
            try
            {
                var candidates = _candidateService.GetAll<CandidateGridDto>();
                var candidatesCount = candidates.Count();

                if (skip != null && take != null)
                    candidates = candidates.Skip((int)skip).Take((int)take);

                candidates = ListHelper<CandidateGridDto>.SortBy(candidates, property, sortBy);

                var response = new Response<CandidateGridDto>
                {
                    Result = candidates,
                    TotalCount = candidatesCount
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
                var user = await _userManager.FindByNameAsync(User.Identity.Name); ;

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
    }
}