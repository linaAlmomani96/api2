using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;

namespace Tahaluf.Portal.Core.Services
{
    public interface IBookService
    {
        Book Create(Book Course);
        Book GetAll();
        Book Update(Book Course);
        Book Delete(int id);
    }
}
