using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tahaluf.Portal.Core.Common;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Repository;
using Tahaluf.Portal.Core.Repositry;

namespace Tahaluf.Portal.Infra.Repository
{
    public class Teacher_CourseRepository : ITeacher_CourseRepository
    {

        private readonly IDBContext DBContext;
        public Teacher_CourseRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Teacher_Course Data)
        {
            var p = new DynamicParameters();
            p.Add("@CourseId", Data.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@TeacherId", Data.TeacherId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("InsertTeacher_Course", p, commandType: CommandType.StoredProcedure);
            return 1;

        }

        public int GetAll()
        {
            var result = DBContext.Connection.ExecuteAsync("GetAllTeacher_Course", commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Update(Teacher_Course Data)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Data.ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CourseId", Data.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@TeacherId", Data.TeacherId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("UpdateTeacher_Course", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteTeacher_Course", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

    }
}
