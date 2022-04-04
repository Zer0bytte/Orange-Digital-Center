using Domains;
using System.Linq;

namespace BusinessLogic.AdminLogic
{
    class AdminAuthentication : IAdminAuthentication
    {
        public ODCCoursesManagmentContext DBContext { get; }

        public AdminAuthentication(ODCCoursesManagmentContext DBContext)
        {
            this.DBContext = DBContext;
        }
        /// <summary>
        /// Login to adminpanel
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        public void Login(string Username, string Password)
        {
            var User = DBContext.TbAdmins.FirstOrDefault(x => x.Username == Username && x.Password == Password);
            if (!User.IsSubAdmin)
            {
                // TODO: SubAdmin Logic
            }
            else
            {
                // TODO: Admin Logic
            }
        }
        /// <summary>
        /// Create SubAdmin
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        public void AssignSubAdmin(string Username, string Password)
        {
            DBContext.TbAdmins.Add(new TbAdmin() { IsSubAdmin = true, Username = Username, Password = Password });
            DBContext.SaveChanges();
        }

    }
}
