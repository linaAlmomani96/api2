using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Tahaluf.Portal.Core.Common
{
   public interface IDBContext
    {
        public DbConnection Connection { get; } //get because without ()
    }
}
