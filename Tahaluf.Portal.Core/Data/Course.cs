using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.Portal.Core.Data
{
   public class Course
    {
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public DateTime CreateDate { set; get; }
        public int CategoryId { set; get; }

        public int UserId { set; get; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Teacher_Course> Teacher_Courses { get; set; }

    }
}
