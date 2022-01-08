using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.Portal.Core.Data
{
    public class Teacher_Course
    {
        public int ID { set; get; }
        [Display(Name ="CourseName")]//design
       public int CourseId { set; get; }
        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }
        [Display(Name = "TeacherName")]
        public int TeacherId { set; get; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { set; get; }
    }
}
