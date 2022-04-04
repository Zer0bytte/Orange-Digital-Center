using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            TbEnrolls = new HashSet<TbEnroll>();
            TbRevisions = new HashSet<TbRevision>();
        }

        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
        public string StudentAddress { get; set; }
        public string StudentCollege { get; set; }
        public DateTime StudentCreatedAt { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<TbEnroll> TbEnrolls { get; set; }
        public virtual ICollection<TbRevision> TbRevisions { get; set; }
    }
}
