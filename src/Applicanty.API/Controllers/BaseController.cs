using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Applicanty.API.Models.Response;
using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Enums;
using Applicanty.Services.Abstract;
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
        public IActionResult ChangeStatus([FromBody]int[] ids, [FromQuery]StatusType status)
        {
            try
            {
                _stateableService.ChangeStatus(ids, status);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ErrorResponse(ex));
            }
        }
    }
}