using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Common;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.DTO;
using Tahaluf.Portal.Core.Repositry;

namespace Tahaluf.Portal.Infra.Repositry
{
  public  class CourseRepositry: ICourseRepositry
    {
        private readonly IDBContext DBContext;
        public CourseRepositry(IDBContext dbContext)
        {
            DBContext = dbContext;
        }
        public int Create(Course Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Name", Data.CourseName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertCourse", p, commandType: CommandType.StoredProcedure);
            return 1; //return 1 to http

        }

        public List<Course> GetAll()
        {
            IEnumerable<Course> result = DBContext.Connection.Query<Course>("GetAllCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public int Delete(int id) {
            var p = new DynamicParameters(); 
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input); 
            var result = DBContext.Connection.ExecuteAsync("DeleteCourse", p, commandType: CommandType.StoredProcedure);
            return 1; 
        }
        public int Update(Course Data) {
            var p = new DynamicParameters();
            p.Add("@Id", Data.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Name", Data.CourseName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateCourse", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        //public List<Course> Search(CourseDTO courseDto)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@CourseName", courseDto.CourseName, dbType: DbType.String, direction: ParameterDirection.Input);
        //    p.Add("@DateFrom", courseDto.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        //    p.Add("@DateTo", courseDto.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        //    p.Add("@CategoryName", courseDto.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
        //    IEnumerable<Course> result = DBContext.Connection.Query<Course>("SearchCourse", p, commandType: CommandType.StoredProcedure);
        //    //collection course return in IEnumerable
        //    //DBContext return from database
        //    //return list in postman test
        //    ///Query < Course > use when we want to return list
        //    /////we can use Query<Course> in Getall fun
        //    //return list 
        //    return result.ToList();

        //}

        public List<Course> Search(CourseDTO courseDto)
        {
            var p = new DynamicParameters();
            p.Add("@CourseName", courseDto.CourseName, DbType.String, direction: ParameterDirection.Input);
            p.Add("@DateFrom", courseDto.DateFrom, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@DateTo", courseDto.DateTo, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@CategoryName", courseDto.CategoryName, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Course> result = DBContext.Connection.Query<Course>("SearchCoursecc", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public async Task<List<Course>> GetAllCourse() //ارجع اشي داخل اشي بوك داخل كورس task
            //task ارجع ليست جواتها ليست
            //النتيجه هون بترجغ course list جواتها بوك ليست
            //asyn يعمل ري بلد كل ك انفذه
        {
            var p = new DynamicParameters();
            var result = await DBContext.Connection.QueryAsync<Course, Book, Course>("GetAll", (course, book) =>
            //await   انه تستنى لتتنفذ الكويري يلي بتعتمد عليها
            //awite دايما بستخدكمها مع async
            //<Course, Book, Course> رح ابعثله كورس وبوك ورح يرجعلي ليست كورس
            //("GetAll", (course, book) هون رح يرجع حسب الفورين كي يعني جوين هسا ببعثله اوبجكت من الكورس والبوك
            //("GetAll", (course, book)رح يرجع الريسلت من خلالهم للاوبجكت
            {
                //هون رح استخدم الريليشنلاوصل للبوك من خلال الكورس
               // course.Books = course.Books ?? new List<Book>() ؟؟هاي زي كأنه بسأله اذا عندك هي الريليشن اعملي ليست من البوك 
              //عملت من الكولكشن ليست وضفت الاوبجكت 
                course.Books = course.Books ?? new List<Book>(); //PUT CATEGORY
                course.Books.Add(book);
                return course;
            }
            //splitOn: "BookId" بحط الاتربيوت يلي بميز البوك اللي هو البرايمري كي لليست الداخلية 
            , splitOn: "BookId" //ADD CATEORY ID
            //param: null البروسيجر م بياخد بارميتر
            , param: null
            , commandType: CommandType.StoredProcedure);
            //لهون عرفتايش رح ياخد وايش رح يرجعي يعني مكافئة للvar result
            //result.AsList<Course>()هون رجعلي ريسلت ع شكل ليست من نوع كورس
            //.GroupBy(p => p.CourseId)يلي عرفته باول الفنكشن p هاد بارميتر خارجي 
            //(p => p.CourseId) اللي بميز الكورس هو اي دي
            var finalResult = result.AsList<Course>().GroupBy(p => p.CourseId).Select(g =>
            { //Course course = g.First(); بيرجعولي كل الكوسز يلي بتطبق هاي جملة السيلكت
                Course course = g.First();
                //هون رح اعرف الكورس على البوك لهون رجعت ليست الكورس ضل البوك
                //g => g.Books.Any() && g.Books.Count > 0) شرط ليرجع البوكز يلي تابعين للكورسز
                course.Books = g.Where(g => g.Books.Any() && g.Books.Count > 0).
                //Select(p => p.Books.Single())هسا هاد الpيلي عرفته قبل رح يشتغل على البوك
                //Select(p => p.Books.Single()) هاي السنجل مش انه يرجع بس اشي واحد لا هو رح يرجعلي مجموعة البوك لتابعين لكورس معين لهيك استخدمتها حتى امنعه انه يرجعلي بوك مش تابع للكورس 
                Select(p => p.Books.Single()).GroupBy(book => book.BookId).
                //   Select(p => p.Books.Single()).GroupBy(book => book.BookId).هسا هون رح ارجع الاتربيوت يلي بالزبط بدي ياهم من البوك  طبعا الاكسس بالفيجوال ع البيز من خلال الكلاسز لهيك استخدمت الاوبجكت book 
                Select(book => new Book
                //هسا هون رح اعمل ليست جديدة تشمل القديمة يعني رح اجهز ليست الكورس وجواها ليست البوك
                {
                    //هون حددت الاتربيوت يلي بدي ياها تظهر من البوك طبعا من خلال الاوبجكت 
                    BookId = book.First().BookId,
                    BookName = book.First().BookName
                }).ToList();//لهون رجعت ليست البوك 
                return course; // بعد م رجعت البوك برجع الليست 
            }).ToList();
            return finalResult; //هون برجع الليست الكامله الكورس داخلها البوك
        }
    }
}

    

