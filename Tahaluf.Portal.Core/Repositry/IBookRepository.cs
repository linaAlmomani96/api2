using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;

namespace Tahaluf.Portal.Core.Repository
{
    public interface IBookRepository
    {
        int Create(Book Data);
        int GetAll();
        int Update(Book Data);
        int Delete(int id);
    }
}
