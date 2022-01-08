using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Repository;
using Tahaluf.Portal.Core.Services;

namespace Tahaluf.Portal.Infra.Services
{
    public class Teacher_CourseService: ITeacher_CourseService
    {
        private readonly ITeacher_CourseRepository Teacher_CourseRepository;
        public Teacher_CourseService(ITeacher_CourseRepository teacher_CourseRepository)
        {
            Teacher_CourseRepository = teacher_CourseRepository;
        }

        public Teacher_Course Create(Teacher_Course teacher_Course)
        {
            Teacher_CourseRepository.Create(teacher_Course);
            return new Teacher_Course();
        }

        public Teacher_Course Update(Teacher_Course teacher_Course)
        {
            Teacher_CourseRepository.Update(teacher_Course);
            return new Teacher_Course();
        }
        public Teacher_Course GetAll()
        {
            Teacher_CourseRepository.GetAll();
            return new Teacher_Course();
        }

        public Teacher_Course Delete(int id)
        {
            Teacher_CourseRepository.Delete(id);
            return new Teacher_Course();
        }
    }
}
