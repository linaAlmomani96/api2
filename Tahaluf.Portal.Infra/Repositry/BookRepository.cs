using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tahaluf.Portal.Core.Common;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Repository;

namespace Tahaluf.Portal.Infra.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IDBContext DBContext;
        public BookRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }
        public int Create(Book Data)
        {
            var p = new DynamicParameters();
            p.Add("@BookName", Data.BookName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CourseId", Data.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("InsertBook", p, commandType: CommandType.StoredProcedure);
            return 1;

        }

        public int GetAll()
        {
            var result = DBContext.Connection.ExecuteAsync("GetAllBooks", commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Update(Book Data)
        {
            var p = new DynamicParameters();
            p.Add("@BookId", Data.BookId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@BookName", Data.BookName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CourseId", Data.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateBook", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@BookId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteBook", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
