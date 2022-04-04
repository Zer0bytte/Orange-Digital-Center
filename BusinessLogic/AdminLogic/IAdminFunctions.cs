using Domains;
using System.Collections.Generic;

namespace BusinessLogic.AdminLogic
{
    public interface IAdminFunctions
    {
      


        public void CreateExamWithQuestions(int CourseId, string QuestionContent, string RightAnswer, string FirstChoice, string SecondChoice, string ThirdChoice, string FourthChoice);
       
        public int SetQuestion(int ExamId, string QuestionContent, string RightAnswer, string FirstChoice, string SecondChoice, string ThirdChoice, string FourthChoice);
       
        public List<TbQuestion> GetExamQuestions(int ExamId);
       
        public void UpdateQuestion(int QuestionId, string QuestionContent, string RightAnswer, string FirstChoice, string SecondChoice, string ThirdChoice, string FourthChoice);
       
        
        public int CreateExam(int CourseId);
        
        public TbExam GetExamById(int ExamId);
        public void UpdateExam(int ExamId,int CourseId);
        public void DeleteExam(int ExamId);

    }
}