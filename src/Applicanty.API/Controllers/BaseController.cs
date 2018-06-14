using System;
using System.Net;
using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Responses;
using Applicanty.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Applicanty.API.Controllers
{
    public class BaseController<TEntity> : Controller
        where TEntity : class, IEntity, IStateable
    {
        private IStateableService<TEntity> _stateableService;
        public BaseController(IStateableService<TEntity> stateableService)
        {
            _stateableService = stateableService;
        }

        [HttpPost("ChangeStatus")]
        public IActionResult ChangeStatus([FromBody]int[] ids, [FromQuery]string status)
        {
            try
            {
                _stateableService.ChangeStatus(ids, status);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}