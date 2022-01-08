using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;

namespace Tahaluf.Portal.Core.Repositry
{
    public interface ITeacherRepository
    {
        int Create(Teacher Data);
        int GetAll();
        int Update(Teacher Data);
        int Delete(int id);
    }
}
