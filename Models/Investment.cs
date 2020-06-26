using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class Investment
    {
        public int Id { get; set; }
        public int? InvestorId { get; set; }
        public int? InvestedCompanyId { get; set; }
        public bool? LeadInvestor { get; set; }
        public int? FundingRoundId { get; set; }
        public double? MoneyRaised { get; set; }
        public int? StockPublised { get; set; }
        public byte[] Date { get; set; }
        public double? PostStockValue { get; set; }
        public double? PreStockValue { get; set; }
        public double? PreValue { get; set; }
        public double? PostValue { get; set; }

        public virtual InvestmentStages FundingRound { get; set; }
        public virtual Company InvestedCompany { get; set; }
        public virtual Investor Investor { get; set; }
    }
}
