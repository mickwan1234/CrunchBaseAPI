using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class InvestorType
    {
        public InvestorType()
        {
            Investor = new HashSet<Investor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Investor> Investor { get; set; }
    }
}
