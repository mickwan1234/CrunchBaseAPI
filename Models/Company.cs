using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class Company
    {
        public Company()
        {
            IndustryList = new HashSet<IndustryList>();
            Investment = new HashSet<Investment>();
            StockHeld = new HashSet<StockHeld>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? FoundedDate { get; set; }
        public int? LocationId { get; set; }
        public string Founder { get; set; }
        public bool? OperatingStatus { get; set; }
        public string NumberOfEmployes { get; set; }
        public string Aka { get; set; }
        public string LegalName { get; set; }
        public int? InvestmentStages { get; set; }
        public string Description { get; set; }
        public double? PreFundingStockValue { get; set; }
        public double? PostFundingStockValue { get; set; }
        public string LastFundingTypeId { get; set; }
        public int? CreatorId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? IsApproved { get; set; }

        public virtual Account Creator { get; set; }
        public virtual InvestmentStages InvestmentStagesNavigation { get; set; }
        public virtual Country Location { get; set; }
        public virtual ICollection<IndustryList> IndustryList { get; set; }
        public virtual ICollection<Investment> Investment { get; set; }
        public virtual ICollection<StockHeld> StockHeld { get; set; }
    }
}
