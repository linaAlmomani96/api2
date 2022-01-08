using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.DTO;

namespace Tahaluf.Portal.Core.Repositry
{
  public  interface ICourseRepositry
    {
        int Create(Course Data);
        //int GetAll();
        public List<Course> GetAll();
        int Update(Course Data);
        int Delete(int id);
        public List<Course> Search(CourseDTO courseDto);
        Task<List<Course>> GetAllCourse();


    }
}
