using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.AdminLogic
{
    public class AdminFunctions : IAdminFunctions
    {
        public ODCCoursesManagmentContext DbContext { get; }
        public AdminFunctions(ODCCoursesManagmentContext dbContext)
        {
            DbContext = dbContext;
        }

        public int SetQuestion(int ExamId,
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


        //public void CreateExamWithQuestions(int CourseId, string QuestionContent,
        //    string RightAnswer,
        //    string FirstChoice,
        //    string SecondChoice, string ThirdChoice, string FourthChoice)
        //{
        //    int ExamId = SetExam(CourseId);
        //    SetQuestions(ExamId, QuestionContent, RightAnswer, FirstChoice, SecondChoice, ThirdChoice, FourthChoice);
        //}


      

        /// <summary>
        /// Send verification Code to user
        /// </summary>
        /// <param name="CourseId">The Course Id </param>
        /// <param name="StudentEmail"</param>
        public void SendCode(int CourseId, string StudentEmail)
        {
            // TODO: Send Verification code by email


        }


       

       
        public void UpdateQuestion(int QuestionId, string QuestionContent, string RightAnswer, string FirstChoice, string SecondChoice, string ThirdChoice, string FourthChoice)
        {

        }

        
    }
}
