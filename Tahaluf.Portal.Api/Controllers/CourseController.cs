using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.DTO;
using Tahaluf.Portal.Core.Services;

namespace Tahaluf.Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseServices CourseService;
        public CourseController(ICourseServices courseService)
        {
            CourseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        public List<Course> GetAll()
        {
            return CourseService.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Course), StatusCodes.Status400BadRequest)]
        public Course Create([FromBody] Course course)
        {
            return CourseService.Create(course);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)] 
        [ProducesResponseType(typeof(Course), StatusCodes.Status400BadRequest)]
        public Course Update([FromBody] Course course) { 
            return CourseService.Update (course);
        }

        [HttpDelete("{id}")] 
        public Course Delete(int id) 
        { 
            return CourseService.Delete(id); 
        }
        [HttpPost]
        [Route("CourseSearch")]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status400BadRequest)]
        public List<Course> Search([FromBody] CourseDTO courseDto)
        {
            return CourseService.Search(courseDto);
        }
        [HttpGet]
        [Route("GetAllCourse")]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        public async Task<List<Course>> GetAllCourse()
        {
            return await CourseService.GetAllCourse();
        }
    }
}
