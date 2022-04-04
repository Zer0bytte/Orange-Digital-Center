using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class ApplicationUser : IdentityUser
    {
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
        public string StudentAddress { get; set; }
        public string StudentCollege { get; set; }
        public DateTime StudentCreatedAt { get; set; }
      

    }
}
