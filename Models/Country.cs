using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class Country
    {
        public Country()
        {
            Company = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Company> Company { get; set; }
    }
}
