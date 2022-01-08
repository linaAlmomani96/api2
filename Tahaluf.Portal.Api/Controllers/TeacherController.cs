using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Services;

namespace Tahaluf.Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherService TeacherService;
        public TeacherController(ITeacherService teacherService)
        {
            TeacherService = teacherService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Teacher), StatusCodes.Status200OK)]
        public Teacher GetAll()
        {
            return TeacherService.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Teacher), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Teacher), StatusCodes.Status400BadRequest)]
        public Teacher Create([FromBody] Teacher Teacher)
        {
            return TeacherService.Create(Teacher);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Teacher), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Teacher), StatusCodes.Status400BadRequest)]
        public Teacher Update([FromBody] Teacher Teacher)
        {
            return TeacherService.Update(Teacher);
        }

        [HttpDelete("{id}")]
        public Teacher Delete(int id)
        {
            return TeacherService.Delete(id);
        }
    }
}
