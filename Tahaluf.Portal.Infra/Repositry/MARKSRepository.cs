using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.Portal.Core.Common;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Repositry;

namespace Tahaluf.Portal.Infra.Repositry
{
  public class MARKSRepository : IMARKSRepository
    {
        private readonly IDBContext DBContext;
        public MARKSRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public List<MARKS> GetAll()
        {
            IEnumerable<MARKS> result = DBContext.Connection.Query<MARKS>("GETALLMARKS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }








    }
    }

