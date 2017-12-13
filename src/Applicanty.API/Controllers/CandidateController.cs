using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Applicanty.Data.Entity;
using Applicanty.Data.Services;

namespace Applicanty.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Candidate")]
    public class CandidateController : Controller
    {
        ICandidateService _candidateService;

        public CandidateController(ICandidateService CandidateService)
        {
            _candidateService = CandidateService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var Candidate = _candidateService.GetOne(id);
            if (Candidate == null)
            {
                return BadRequest();
            }
            return Json(Candidate);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Candidate = _candidateService.GetAll();
            return Json(Candidate);
        }

        [HttpPost("{model}")]
        public IActionResult Create(Candidate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            _candidateService.Create(model);
            return Ok();
        }

        [HttpPut("{model}")]
        public IActionResult Edit(Candidate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            _candidateService.Create(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Archive(long id)
        {
            _candidateService.Archive(id);
            return Ok();
        }
    }
}