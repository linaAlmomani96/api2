using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;

namespace Tahaluf.Portal.Core.Services
{
    public interface ITeacher_CourseService
    {
        Teacher_Course Create(Teacher_Course teacher_Course);
        Teacher_Course GetAll();
        Teacher_Course Update(Teacher_Course teacher_Course);
        Teacher_Course Delete(int id);
    }
}
