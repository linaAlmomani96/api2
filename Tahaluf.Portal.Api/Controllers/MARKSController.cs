using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Services;

namespace Tahaluf.Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MARKSController : ControllerBase
    {

        private readonly IMARKStService MARKStService;
        public MARKSController(IMARKStService mARKStService)
        {
            MARKStService = mARKStService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(MARKS), StatusCodes.Status200OK)]
        public List<MARKS> GetAll()
        {
            return MARKStService.GetAll();
        }

    }
}
