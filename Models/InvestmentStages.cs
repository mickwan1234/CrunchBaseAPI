using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class InvestmentStages
    {
        public InvestmentStages()
        {
            Company = new HashSet<Company>();
            Investment = new HashSet<Investment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<Investment> Investment { get; set; }
    }
}
