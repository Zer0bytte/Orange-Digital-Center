using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AdminLogic
{
    class cslStudents
    {
        public ODCCoursesManagmentContext DbContext { get; }
        public cslStudents(ODCCoursesManagmentContext DbContext)
        {
            this.DbContext = DbContext;
        }


        public TbStudent GetStudentById(int StudentId)
        {
            TbStudent Student = DbContext.TbStudents.Include(x => x.TbRevisions).FirstOrDefault(x => x.StudentId == StudentId);
            return Student;
        }

        public TbRevision GetStudentExam(int StudentId)
        {
            TbStudent Student = GetStudentById(StudentId);
            TbRevision StudentRevision = Student.TbRevisions.FirstOrDefault();
            return StudentRevision;
        }
    }
}
