using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AdminLogic.Classes
{
    class StudentsStructure : IStudentsStructure
    {
        public ODCCoursesManagmentContext DbContext { get; }
        public StudentsStructure(ODCCoursesManagmentContext DbContext)
        {
            this.DbContext = DbContext;
        }


        public TbStudent GetStudentById(int StudentId)
        {
            TbStudent Student = DbContext.TbStudents.FirstOrDefault(x => x.StudentId == StudentId);
            return Student;
        }
    }
}
