using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class Account
    {
        public Account()
        {
            Company = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool? ContributorStatus { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Company> Company { get; set; }
    }
}
