using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;

namespace Tahaluf.Portal.Core.Services
{
    public interface ITeacherService
    {
        Teacher Create(Teacher teacher);
        Teacher GetAll();
        Teacher Update(Teacher teacher);
        Teacher Delete(int id);
    }
}
