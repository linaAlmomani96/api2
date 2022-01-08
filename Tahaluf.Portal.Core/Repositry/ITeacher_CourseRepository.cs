using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;

namespace Tahaluf.Portal.Core.Repository
{
    public interface ITeacher_CourseRepository
    {
        int Create(Teacher_Course Data);
        int GetAll();
        int Update(Teacher_Course Data);
        int Delete(int id);
    }
}
