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
    public class TeacherRepository : ITeacherRepository
    {

        private readonly IDBContext DBContext;
        public TeacherRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Teacher Data)
        {
            var p = new DynamicParameters();
            p.Add("@FirstName", Data.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastName", Data.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Phone", Data.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Photo", Data.Photo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Email", Data.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Salary", Data.Salary, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@HireDate", Data.HairDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@BirthOfDate", Data.Photo, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("InsertTeacher", p, commandType: CommandType.StoredProcedure);
            return 1;

        }

        public int GetAll()
        {
            var result = DBContext.Connection.ExecuteAsync("GetAllTeacher", commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Update(Teacher Data)
        {
            var p = new DynamicParameters();
            p.Add("@TeacherId", Data.TeacherId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@FirstName", Data.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastName", Data.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Phone", Data.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Photo", Data.Photo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Email", Data.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Salary", Data.Salary, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@HireDate", Data.HairDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@BirthOfDate", Data.Photo, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("UpdateTeacher", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@TeacherId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteTeacher", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

    }
}
