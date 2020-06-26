using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class StockHeld
    {
        public int Id { get; set; }
        public int? InvestorId { get; set; }
        public int? InvestedCompanyId { get; set; }
        public int? StockHeld1 { get; set; }

        public virtual Company InvestedCompany { get; set; }
        public virtual Investor Investor { get; set; }
    }
}
