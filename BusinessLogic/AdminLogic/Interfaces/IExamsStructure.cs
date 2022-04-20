using Domains;
using System.Collections.Generic;

namespace BusinessLogic.AdminLogic
{
    interface IExamsStructure
    {
        ODCCoursesManagmentContext DbContext { get; }

        int CreateExam(int CourseId);
        void DeleteExam(int ExamId);
        TbExam GetExamById(int ExamId);
        List<TbQuestion> GetExamQuestions(int ExamId);
        TbRevision GetStudentExam(int StudentId);
        void UpdateExam(int ExamId, int CourseId);
    }
}