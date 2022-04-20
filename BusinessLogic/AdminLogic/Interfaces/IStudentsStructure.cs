using Domains;

namespace BusinessLogic.AdminLogic
{
   public interface IStudentsStructure
    {

        TbStudent GetStudentById(int StudentId);
    }
}