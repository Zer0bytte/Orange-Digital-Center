using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AdminLogic
{
    class ExamsStructure : IExamsStructure
    {
        public ODCCoursesManagmentContext DbContext { get; }
        public IStudentsStructure StudentStructure { get; }

        public ExamsStructure(ODCCoursesManagmentContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public int CreateExam(int CourseId, IStudentsStructure StudentStructure)
        {
            //Create Exam
            TbExam Exam = new TbExam();
            Exam.CourseId = CourseId;
            DbContext.TbExams.Add(Exam);
            DbContext.SaveChanges();
            return Exam.ExamId;
        }


        public TbExam GetExamById(int ExamId)
        {
            TbExam Exam = DbContext.TbExams.FirstOrDefault(x => x.ExamId == ExamId);
            return Exam;
        }

        public void UpdateExam(int ExamId, int CourseId)
        {
            TbExam Exam = GetExamById(ExamId);
            Exam.CourseId = CourseId;
            DbContext.SaveChanges();
        }

        public void DeleteExam(int ExamId)
        {
            TbExam Exam = GetExamById(ExamId);
            DbContext.Remove(Exam);
            DbContext.SaveChanges();

        }


        public List<TbQuestion> GetExamQuestions(int ExamId)
        {
            var Questions = DbContext.TbQuestions.Where(x => x.ExamId == ExamId).ToList();
            return Questions;
        }


        public TbRevision GetStudentExam(int StudentId)
        {
            TbStudent Student = StudentStructure.GetStudentById(StudentId);
            TbRevision StudentRevision = Student.TbRevisions.FirstOrDefault();
            return StudentRevision;
        }

        public int CreateExam(int CourseId)
        {
            
        }
    }
}
