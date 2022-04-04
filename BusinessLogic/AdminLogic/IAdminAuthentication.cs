using Domains;

namespace BusinessLogic.AdminLogic
{
   public interface IAdminAuthentication
    {
        ODCCoursesManagmentContext DBContext { get; }

        void AssignSubAdmin(string Username, string Password);
        void Login(string Username, string Password);
    }
}