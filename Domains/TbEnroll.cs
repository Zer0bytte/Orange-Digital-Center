using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbEnroll
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual TbCourse Course { get; set; }
        public virtual AspNetUser Student { get; set; }
    }
}
