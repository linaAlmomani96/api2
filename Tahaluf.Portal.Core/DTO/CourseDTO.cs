using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.Portal.Core.DTO
{
   public class CourseDTO
    {
        public string CourseName { set; get; }
        
        public DateTime? DateFrom { set; get; } //? allow null
        public DateTime? DateTo { set; get; }//? prevent execption handling
        public string CategoryName { set; get; }

    }
}
