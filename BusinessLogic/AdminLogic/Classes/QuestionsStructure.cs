using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AdminLogic.Classes
{
   public class QuestionsStructure
    {
        public ODCCoursesManagmentContext DbContext { get; }
        public QuestionsStructure(ODCCoursesManagmentContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public int AddQuestion(int ExamId,
          string QuestionContent,
          string RightAnswer,
          string FirstChoice,
          string SecondChoice, string ThirdChoice, string FourthChoice)
        {
            TbQuestion question = new TbQuestion();
            question.ExamId = ExamId;
            question.QuestionContent = QuestionContent;
            question.QuestionRightAnswer = RightAnswer;
            question.FirstChoice = FirstChoice;
            question.SecondChoice = SecondChoice;
            question.ThirdChoice = ThirdChoice;
            question.FourthChoice = FourthChoice;
            DbContext.TbQuestions.Add(question);
            DbContext.SaveChanges();
            return question.Id;
        }
    }
}
