using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Services;
using Tahaluf.Portal.Infra.Services;

namespace Tahaluf.Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teacher_CourseController : Controller
    {
        private readonly Teacher_CourseService Teacher_CourseService;
        public Teacher_CourseController(Teacher_CourseService teacher_CourseService)
        {
            Teacher_CourseService = teacher_CourseService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Teacher_Course), StatusCodes.Status200OK)]
        public Teacher_Course GetAll()
        {
            return Teacher_CourseService.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Teacher_Course), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Teacher_Course), StatusCodes.Status400BadRequest)]
        public Teacher_Course Create([FromBody] Teacher_Course teacherCourses)
        {
            return Teacher_CourseService.Create(teacherCourses);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Teacher_Course), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Teacher_Course), StatusCodes.Status400BadRequest)]
        public Teacher_Course Update([FromBody] Teacher_Course teacherCourses)
        {
            return Teacher_CourseService.Update(teacherCourses);
        }

        [HttpDelete("{id}")]
        public Teacher_Course Delete(int id)
        {
            return Teacher_CourseService.Delete(id);
        }
    }
}
