using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.DTO;

namespace Tahaluf.Portal.Core.Services
{
   public interface ICourseServices
    {
        Course Create(Course course);
        //Course GetAll();
        public List<Course> GetAll();
        Course Delete(int id);
        Course Update(Course course);
        public List<Course> Search(CourseDTO courseDto);
        Task<List<Course>> GetAllCourse();
    }
}
