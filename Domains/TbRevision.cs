using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbRevision
    {
        public int Id { get; set; }
        public decimal StudentDegree { get; set; }
        public decimal TotalRightDegrees { get; set; }
        public decimal TotalWrongDegrees { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }

        public virtual TbExam Exam { get; set; }
        public virtual AspNetUser Student { get; set; }
    }
}
