using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.DTO;
using Tahaluf.Portal.Core.Repositry;
using Tahaluf.Portal.Core.Services;

namespace Tahaluf.Portal.Infra.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepositry CourseRepository;
        public CourseServices(ICourseRepositry courseRepository)
        {
            CourseRepository = courseRepository;
        }

        public Course Create(Course course)
        {
            CourseRepository.Create(course);
            return new Course();
        }

        public List<Course> GetAll()
        {
            //CourseRepository.GetAll();
            //return new Course();
            return CourseRepository.GetAll();
        }

        public Course Update(Course course)
        {
            CourseRepository.Update(course);
            return course;
        }


        public Course Delete(int id)
        {
            CourseRepository.Delete(id);
            return new Course();
        }

        //public List<Course> Search(CourseDTO courseDto)
        //{
        //  return CourseRepository.Search(courseDto);

        //}
        public List<Course> Search(CourseDTO courseDto)
        {
            return CourseRepository.Search(courseDto);
        }

        public async Task<List<Course>> GetAllCourse()
        {
            return await CourseRepository.GetAllCourse();
        }
    }
}