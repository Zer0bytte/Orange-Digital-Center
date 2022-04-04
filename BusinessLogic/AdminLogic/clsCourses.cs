using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AdminLogic
{
    public class clsCourses
    {
        public ODCCoursesManagmentContext DbContext { get; }

        public clsCourses(ODCCoursesManagmentContext dbContext)
        {
            DbContext = dbContext;
        }


        public void CreateCourse(string CourseName, int CategoryId, string CourseLevel)
        {
            TbCourse Course = new TbCourse();
            Course.CourseName = CourseName;
            Course.CourseLevel = CourseLevel;
            Course.CategoryId = CategoryId;
            Course.CreatedAt = DateTime.Now;
            DbContext.TbCourses.Add(Course);
            DbContext.SaveChanges();

        }
        public TbCourse GetCourseById(int CourseId)
        {
            TbCourse Course = DbContext.TbCourses.FirstOrDefault(x => x.CourseId == CourseId);
            return Course;
        }

        public void UpdateCourse(int CourseId, string CourseName, int CategoryId, string CourseLevel)
        {
            TbCourse Course = GetCourseById(CourseId);
            Course.CourseName = CourseName;
            Course.CategoryId = CategoryId;
            Course.CourseLevel = CourseLevel;
            DbContext.SaveChanges();
        }

        public void DeleteCourse(int CourseId)
        {
            TbCourse Course = GetCourseById(CourseId);
            DbContext.TbCourses.Remove(Course);
            DbContext.SaveChanges();

        }
    }
}
