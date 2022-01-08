using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.Portal.Core.Data
{
   public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }

    }
}