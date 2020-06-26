using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class Investor
    {
        public Investor()
        {
            Investment = new HashSet<Investment>();
            StockHeld = new HashSet<StockHeld>();
        }

        public int Id { get; set; }
        public int? LocationId { get; set; }
        public int? FoundedDate { get; set; }
        public string Founders { get; set; }
        public string Aka { get; set; }
        public int? InvestorTypeId { get; set; }
        public string Description { get; set; }

        public virtual InvestorType InvestorType { get; set; }
        public virtual ICollection<Investment> Investment { get; set; }
        public virtual ICollection<StockHeld> StockHeld { get; set; }
    }
}
