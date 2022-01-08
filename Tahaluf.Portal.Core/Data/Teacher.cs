using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.Portal.Core.Data
{
  public  class Teacher
    {
        public int TeacherId { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Phone { set; get; }
        public string Photo { set; get; }
        public string Email { set; get; }
        public float Salary { set; get; }
        public DateTime HairDate { set; get; }
        public DateTime BirthOfDate { set; get; }
        public ICollection<Teacher_Course> teacher_Courses { set; get; }

    }
}
