using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Repository;
using Tahaluf.Portal.Core.Repositry;
using Tahaluf.Portal.Core.Services;

namespace Tahaluf.Portal.Infra.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository TeacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            TeacherRepository = teacherRepository;
        }

        public Teacher Create(Teacher teacher)
        {
            TeacherRepository.Create(teacher);
            return new Teacher();
        }

        public Teacher Update(Teacher teacher)
        {
            TeacherRepository.Update(teacher);
            return new Teacher();
        }
        public Teacher GetAll()
        {
            TeacherRepository.GetAll();
            return new Teacher();
        }

        public Teacher Delete(int id)
        {
            TeacherRepository.Delete(id);
            return new Teacher();
        }

    }
}
